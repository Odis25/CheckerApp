using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Models.Hardware;
using Microsoft.AspNetCore.Components;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class UpdateNetworkDevice
    {
        [Parameter] public NetworkDeviceDto NetworkDevice { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        private NetworkDeviceDto Value { get; set; } = new NetworkDeviceDto();


        protected override void OnParametersSet()
        {
            Value.Id = NetworkDevice.Id;
            Value.IP = NetworkDevice.IP;
            Value.MacAddress = NetworkDevice.MacAddress;
            Value.Name = NetworkDevice.Name;
        }
        public async void Save()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(Value));
        }
        
    }
}
