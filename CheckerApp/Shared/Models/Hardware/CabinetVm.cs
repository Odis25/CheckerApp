using System;

namespace CheckerApp.Shared.Models.Hardware
{
    public class CabinetVm : HardwareVm
    {
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
