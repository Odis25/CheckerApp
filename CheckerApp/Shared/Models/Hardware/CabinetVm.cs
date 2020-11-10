using System;
using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class CabinetVm : HardwareVm
    {
        public CabinetVm()
        {
            HardwareType = HardwareType.Cabinet;
        }
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
