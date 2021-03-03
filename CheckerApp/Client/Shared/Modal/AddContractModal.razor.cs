using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Models.Commands;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class AddContractModal
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        CreateContractCommandVm Contract;

        protected override Task OnInitializedAsync()
        {
            Contract = new CreateContractCommandVm();
            return base.OnInitializedAsync();
        }

        protected async Task Submit()
        {
            var contractId = await HttpClient.PostJsonAsync<int>("api/contract", Contract);

            await BlazoredModal.CloseAsync(ModalResult.Ok(contractId));
        }
    }
}
