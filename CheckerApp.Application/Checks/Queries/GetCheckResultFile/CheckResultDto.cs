using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class CheckResultDto
    {
        public ContractDto Contract { get; set; }
        public IEnumerable<HardwareCheckDto> HardwareChecks { get; set; }
        public IEnumerable<SoftwareCheckDto> SoftwareChecks { get; set; }
    }
}
