using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class PlcVm : ControllerVm
    {
        public PlcVm()
        {
            HardwareType = HardwareType.PLC;
        }
    }
}
