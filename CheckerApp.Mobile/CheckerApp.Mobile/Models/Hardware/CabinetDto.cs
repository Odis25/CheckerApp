using System;
using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class CabinetDto : HardwareDto
    {
        public CabinetDto()
        {
            HardwareType = HardwareType.Cabinet;
        }
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
