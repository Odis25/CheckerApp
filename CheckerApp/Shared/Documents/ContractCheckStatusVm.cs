using System.Collections.Generic;

namespace CheckerApp.Shared.Documents
{
    public class ContractCheckStatusVm
    {
        public ContractCheckStatusVm()
        {
            HardwareChecks = new HashSet<HardwareCheckStatusDto>();
        }

        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public ICollection<HardwareCheckStatusDto> HardwareChecks { get; set; }
    }
}
