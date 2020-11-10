using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class PressureVm : MeasurementVm
    {
        public PressureVm()
        {
            HardwareType = HardwareType.Pressure;
        }
    }
}
