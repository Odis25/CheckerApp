using CheckerApp.Shared.Enums;
using CheckerApp.Shared.Models.Checks;
using Microsoft.AspNetCore.Components;

namespace CheckerApp.Client.Shared
{
    public partial class SoftwareCheckStatus
    {
        [Parameter] public SoftwareCheckDto Value { get; set; }

        [Parameter] public EventCallback<SoftwareCheckDto> ValueChanged { get; set; }

        string Title { get; set; }

        protected override void OnInitialized()
        {
            Title = $"{Value.Software.SoftwareType.GetDisplayName()}: {Value.Software.Name} ver. {Value.Software.Version}";
        }
    }
}
