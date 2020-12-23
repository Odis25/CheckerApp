using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Client.Shared.Modal;
using CheckerApp.Shared.Common.JsonConverters;
using CheckerApp.Shared.Models;
using CheckerApp.Shared.Models.Contract;
using CheckerApp.Shared.Models.Hardware;
using CheckerApp.Shared.Models.Software;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Pages
{
    public partial class ContractDetail
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] IModalService Modal { get; set; }
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        [Parameter] public string Id { get; set; }

        protected ContractDetailVm Contract { get; set; }

        protected string ProtocolCss => Contract.HasProtocol ? "protocol" : "no-protocol";

        protected override async Task OnParametersSetAsync()
        {
            var client = HttpClientFactory.CreateClient("ServerAPI.NonAuthorized");

            Contract = await client.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");
        }

        private void NavigateTo(int id)
        {
            NavigationManager.NavigateTo($"/hardware/{id}/detail");
        }

        private async Task AddHardware()
        {
            var parameters = new ModalParameters();

            parameters.Add("ContractId", Id);

            var modalForm = Modal.Show<AddHardwareModal>("Новое оборудование", parameters);
            var result = await modalForm.Result;

            if (!result.Cancelled)
            {
                Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");
            }
        }

        private async Task ImportHardwareAsync(InputFileChangeEventArgs e)
        {
            if (!e.File.ContentType.Equals("text/xml", StringComparison.OrdinalIgnoreCase)) return;

            var buffer = new byte[e.File.Size];

            using (var stream = e.File.OpenReadStream())
            {
                await stream.ReadAsync(buffer);
            }

            var file = new FileModel
            {
                FileName = e.File.Name,
                ContentType = e.File.ContentType,
                Content = buffer,
                Size = e.File.Size
            };

            await HttpClient.PostJsonAsync($"/api/hardware/import/{Id}", file);

            Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");
        }

        private async Task AddSoftware()
        {
            var parameters = new ModalParameters();

            parameters.Add("ContractId", Id);

            var modalForm = Modal.Show<AddSoftwareModal>("Новое ПО", parameters);
            var result = await modalForm.Result;

            if (!result.Cancelled)
            {
                Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");
            }
        }

        private void DownloadFile()
        {
            NavigationManager.NavigateTo($"/api/check/download/{Id}", true);
        }

        private void AddDocument()
        {
            NavigationManager.NavigateTo($"/contract/{Id}/check");
        }

        private async Task EditHardware(int id)
        {
            var options = new JsonSerializerOptions { Converters = { new HardwareConverter() } };

            var hardware = await HttpClient.GetFromJsonAsync<HardwareVm>($"api/hardware/{id}", options);

            var parameters = new ModalParameters();

            parameters.Add("Hardware", hardware);

            var modalWindow = Modal.Show<UpdateHardwareModal>("Редактирование оборудования", parameters);

            var result = await modalWindow.Result;

            if (!result.Cancelled)
            {
                Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");
            }
        }

        private async Task DeleteHardware(int id)
        {
            await HttpClient.DeleteAsync($"api/hardware/{id}");

            Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{int.Parse(Id)}");
        }

        private async Task EditSoftware(int id)
        {
            var software = await HttpClient.GetFromJsonAsync<SoftwareDto>($"api/software/{id}");

            var parameters = new ModalParameters();

            parameters.Add("Software", software);

            var modalWindow = Modal.Show<UpdateSoftwareModal>("Редактирование ПО", parameters);

            var result = await modalWindow.Result;

            if (!result.Cancelled)
            {
                Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");
            }
        }

        private async Task DeleteSoftware(int id)
        {
            await HttpClient.DeleteAsync($"api/software/{id}");

            Contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{int.Parse(Id)}");
        }
    }
}
