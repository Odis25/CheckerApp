using CheckerApp.Shared.Hardware;
using System.Collections.Generic;

namespace CheckerApp.Shared.Documents
{
    public class HardwareCheckStatusDto
    {
        public HardwareCheckStatusDto()
        {
            CheckParameters = new List<CheckParameter>();
        }

        public HardwareVm Device { get; set; }
        public IList<CheckParameter> CheckParameters { get; set; }
    }
}
