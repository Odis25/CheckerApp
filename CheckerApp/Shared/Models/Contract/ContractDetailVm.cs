using CheckerApp.Shared.Models.Hardware;
using CheckerApp.Shared.Models.Software;
using System.Collections.Generic;

namespace CheckerApp.Shared.Models.Contract
{
    public class ContractDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public bool HasProtocol { get; set; }

        public IEnumerable<HardwareVm> HardwareList { get; set; }
        public IEnumerable<SoftwareDto> SoftwareList { get; set; }
    }
}
