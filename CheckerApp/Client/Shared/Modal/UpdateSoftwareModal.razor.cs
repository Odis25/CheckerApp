using Blazored.Modal;
using Blazored.Modal.Services;
using CheckerApp.Shared.Common.JsonConverters;
using CheckerApp.Shared.Models.Commands;
using CheckerApp.Shared.Models.Software;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Shared.Modal
{
    public partial class UpdateSoftwareModal
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public SoftwareDto Software {get;set;}
        public UpdateSoftwareCommandVm Command { get; set; }

        protected override void OnInitialized()
        {
            Command = new UpdateSoftwareCommandVm
            {
                Id = Software.Id,
                Name = Software.Name,
                Version = Software.Version
            };
        }
        protected async Task Submit()
        {
            var options = new JsonSerializerOptions { Converters = { new SoftwareConverter() } };

            await HttpClient.PutAsJsonAsync("api/software", Command, options);

            await BlazoredModal.Close(ModalResult.Ok(Software.Id));
        }
    }
}
