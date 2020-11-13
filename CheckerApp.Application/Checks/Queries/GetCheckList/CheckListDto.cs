using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries.GetCheckList
{
    public class CheckListDto
    {
        public CheckListDto()
        {
            HardwareChecks = new HashSet<HardwareCheckDto>();
            SoftwareChecks = new HashSet<SoftwareCheckDto>();
        }

        public ContractDto Contract { get; set; }
        public ICollection<HardwareCheckDto> HardwareChecks { get; set; }
        public ICollection<SoftwareCheckDto> SoftwareChecks { get; set; }
    }
}
