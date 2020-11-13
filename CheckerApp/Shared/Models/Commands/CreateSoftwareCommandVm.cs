
using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Commands
{
    public class CreateSoftwareCommandVm
    {
        public int ContractId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public SoftwareType SoftwareType { get; set; }
    }
}
