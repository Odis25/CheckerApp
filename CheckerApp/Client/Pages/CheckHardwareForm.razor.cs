using CheckerApp.Shared.Common.JsonConverters;
using CheckerApp.Shared.Models.Checks;
using CheckerApp.Shared.Models.Commands;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Pages
{
    public partial class CheckHardwareForm
    {
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] protected NavigationManager Navigation { get; set; }

        [Parameter] public string Id { get; set; }

        protected CheckListVm CheckList { get; set; } = new CheckListVm();

        protected SoftwareCheckDto[] ScadaList { get; set; }

        JsonSerializerOptions JsonOptions { get; set; }

        protected async override Task OnInitializedAsync()
        {
            JsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = 
                { 
                    new HardwareConverter(), 
                    new SoftwareConverter() 
                }
            };

            CheckList = await HttpClient.GetFromJsonAsync<CheckListVm>($"api/check/{int.Parse(Id)}", JsonOptions);

            ScadaList = CheckList.SoftwareChecks.Where(e => e.Software is CheckerApp.Shared.Models.Software.ScadaDto).ToArray();
        }

        protected async Task Submit()
        {
            var command = new UpsertCheckResultCommandVm { CheckResult = CheckList };

            var result = await HttpClient.PostAsJsonAsync($"api/check", command, JsonOptions);

            if (result.IsSuccessStatusCode)
            {
                Navigation.NavigateTo($"/contract/{Id}/detail");
            }
        }
    }
}
