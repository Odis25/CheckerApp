using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Client.Shared.Modal;
using CheckerApp.Shared.Models.Contract;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Pages
{
    public partial class Contracts
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] IModalService Modal { get; set; }
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        ContractsListVm ContractsList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = HttpClientFactory.CreateClient("ServerAPI.NonAuthorized");
            ContractsList = await client.GetFromJsonAsync<ContractsListVm>("api/contract");
        }

        private void NavigateTo(int id)
        {
            NavigationManager.NavigateTo($"/contract/{id}/detail");
        }

        private async Task AddContract()
        {
            var formModal = Modal.Show<AddContractModal>("Новый договор");
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                ContractsList = await HttpClient.GetFromJsonAsync<ContractsListVm>("api/contract");
            }
        }

        private async Task EditContract(int id)
        {
            var contract = await HttpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{id}");

            var parameters = new ModalParameters();

            parameters.Add("Contract", contract);

            var modalWindow = Modal.Show<UpdateContractModal>("Редактирование договора", parameters);

            var result = await modalWindow.Result;

            if (!result.Cancelled)
            {
                ContractsList = await HttpClient.GetFromJsonAsync<ContractsListVm>("api/contract");
            }
        }

        private async Task DeleteContract(int id)
        {
            await HttpClient.DeleteAsync($"api/contract/{id}");

            ContractsList = await HttpClient.GetFromJsonAsync<ContractsListVm>("api/contract");
        }
    }
}
