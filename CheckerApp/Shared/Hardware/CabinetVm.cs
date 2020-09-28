using System;

namespace CheckerApp.Shared.Hardware
{
    public class CabinetVm : HardwareVm
    {
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
