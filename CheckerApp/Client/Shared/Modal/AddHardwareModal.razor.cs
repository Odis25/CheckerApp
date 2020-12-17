using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Enums;
using CheckerApp.Shared.Models.Commands;
using CheckerApp.Shared.Models.Hardware;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class AddHardwareModal
    {
        private readonly HardwareType[] _hardwareTypes = Enum.GetValues(typeof(HardwareType)).Cast<HardwareType>().ToArray();

        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [CascadingParameter] IModalService Modal { get; set; }
        [Parameter] public string ContractId { get; set; }

        CreateHardwareCommandVm Command { get; set; }

        protected override void OnInitialized()
        {
            Command = new CreateHardwareCommandVm
            {
                ContractId = int.Parse(ContractId)
            };
        }

        private async Task Submit()
        {
            var hardwareId = await HttpClient.PostJsonAsync<int>("api/hardware", Command);

            await BlazoredModal.Close(ModalResult.Ok(hardwareId));
        }

        private async Task AddNetworkDevice()
        {
            var modalForm = Modal.Show<AddNetworkDeviceModal>("");
            var result = await modalForm.Result;

            if (!result.Cancelled)
            {
                var device = (NetworkDeviceDto)result.Data;
                Command.NetworkDevices.Add(device);
            }
        }
    }
}
