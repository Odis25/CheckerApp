using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Models.Hardware;
using Microsoft.AspNetCore.Components;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class AddNetworkDeviceModal
    {
        public NetworkDeviceDto Device { get; set; } = new NetworkDeviceDto();

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        private void Save()
        {
            BlazoredModal.CloseAsync(ModalResult.Ok(Device));
        }
    }
}
