using System.Collections.Generic;

namespace CheckerApp.Application.Documents.Queries
{
    public class ContractCheckStatusVm
    {
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public ICollection<HardwareCheckStatusDto> HardwareChecks { get; set; }
    }
}
