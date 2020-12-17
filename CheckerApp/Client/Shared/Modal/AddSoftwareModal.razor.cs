using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Enums;
using CheckerApp.Shared.Models.Commands;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class AddSoftwareModal
    {
        private readonly SoftwareType[] _softwareTypes = Enum.GetValues(typeof(SoftwareType)).Cast<SoftwareType>().ToArray();

        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public string ContractId { get; set; }

        CreateSoftwareCommandVm Command { get; set; }

        protected override void OnInitialized()
        {
            Command = new CreateSoftwareCommandVm
            {
                ContractId = int.Parse(ContractId)
            };
        }

        private async Task Submit()
        {
            var softwareId = await HttpClient.PostJsonAsync<int>("api/software", Command);

            await BlazoredModal.Close(ModalResult.Ok(softwareId));
        }
    }
}
