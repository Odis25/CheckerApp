using System;

namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class CabinetVm : HardwareVm
    {
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
