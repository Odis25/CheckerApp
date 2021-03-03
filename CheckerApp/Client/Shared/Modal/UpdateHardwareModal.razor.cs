using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Common.JsonConverters;
using CheckerApp.Shared.Models.Commands;
using CheckerApp.Shared.Models.Hardware;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class UpdateHardwareModal
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public HardwareVm Hardware { get; set; }

        UpdateHardwareCommandVm Command { get; set; }

        protected override void OnParametersSet()
        {
            Command = new UpdateHardwareCommandVm
            {
                Hardware = Hardware
            };
        }

        protected async Task Submit()
        {
            var options = new JsonSerializerOptions { Converters = { new HardwareConverter() } };

            await HttpClient.PutAsJsonAsync("api/hardware", Command, options);

            await BlazoredModal.CloseAsync(ModalResult.Ok(Hardware.Id));
        }
    }
}
