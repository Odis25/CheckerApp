using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Client.Shared.Modal;
using CheckerApp.Shared.Models.Contract;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Pages
{
    public partial class Contracts
    {
        private bool isSortedAscending;
        private string activeSortColumn;

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

        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                ContractsList.Contracts = ContractsList.Contracts.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;
            }
            else
            {
                if (isSortedAscending)
                {
                    ContractsList.Contracts = ContractsList.Contracts.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    ContractsList.Contracts = ContractsList.Contracts.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                isSortedAscending = !isSortedAscending;
            }
        }

        private string SetSortIcon(string columnName)
        {
            if (activeSortColumn != columnName)
            {
                return string.Empty;
            }
            if (isSortedAscending)
            {
                return "oi-sort-ascending";
            }
            else
            {
                return "oi-sort-descending";
            }
        }
    }
}
