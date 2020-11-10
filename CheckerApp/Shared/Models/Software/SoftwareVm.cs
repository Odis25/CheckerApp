using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Software
{
    public class SoftwareVm
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public SoftwareType SoftwareType { get; set; }
    }
}
