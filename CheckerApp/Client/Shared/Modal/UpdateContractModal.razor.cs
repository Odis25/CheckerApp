using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Models.Commands;
using CheckerApp.Shared.Models.Contract;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class UpdateContractModal
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public ContractDetailVm Contract { get; set; }

        UpdateContractCommandVm Command { get; set; }

        protected override void OnParametersSet()
        {
            Command = new UpdateContractCommandVm
            {
                Id = Contract.Id,
                Name = Contract.Name,
                ContractNumber = Contract.ContractNumber,
                ProjectNumber = Contract.ProjectNumber,
                DomesticNumber = Contract.DomesticNumber
            };
        }

        protected async Task Submit()
        {
            await HttpClient.PutJsonAsync("api/contract", Command);

            await BlazoredModal.CloseAsync(ModalResult.Ok(Contract.Id));
        }
    }
}
