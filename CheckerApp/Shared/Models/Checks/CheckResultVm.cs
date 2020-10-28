using CheckerApp.Shared.Models.Contract;
using System.Collections.Generic;

namespace CheckerApp.Shared.Models.Checks
{
    public class CheckResultVm
    {
        public CheckResultVm()
        {
            HardwareChecks = new List<HardwareCheckDto>();
        }
        public int? Id { get; set; }
        public ContractDto Contract { get; set; }
        public IList<HardwareCheckDto> HardwareChecks { get; set; }
    }
}
