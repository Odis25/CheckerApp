using CheckerApp.Shared.Models.Contract;
using System.Collections.Generic;

namespace CheckerApp.Shared.Models.Checks
{
    public class CheckListVm
    {
        public CheckListVm()
        {
            HardwareChecks = new List<HardwareCheckDto>();
            SoftwareChecks = new List<SoftwareCheckDto>();
        }
        public ContractDto Contract { get; set; }
        public IList<HardwareCheckDto> HardwareChecks { get; set; }
        public IList<SoftwareCheckDto> SoftwareChecks { get; set; }
    }
}
