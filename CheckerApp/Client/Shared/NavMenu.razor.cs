using Blazored.Modal.Services;
using CheckerApp.Client.Shared.Modal;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared
{
    public partial class NavMenu
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IModalService Modal { get; set; }

        private bool _collapseNavMenu = true;

        private string NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        private async Task AddContract()
        {
            var formModal = Modal.Show<AddContractModal>("Новый договор");
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var contractId = result.Data.ToString();

                NavigationManager.NavigateTo($"/contract/{contractId}/detail");
            }
        }
    }
}
