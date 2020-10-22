using CheckerApp.Shared.Models.Contract;
using System.Collections.Generic;

namespace CheckerApp.Shared.Models.Checks
{
    public class ContractCheckVm
    {
        public ContractCheckVm()
        {
            HardwareChecks = new List<HardwareCheckDto>();
        }

        public ContractDto Contract { get; set; }
        public IList<HardwareCheckDto> HardwareChecks { get; set; }
    }
}
