using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class DiffPressureVm : MeasurementVm
    {
        public DiffPressureVm()
        {
            HardwareType = HardwareType.DiffPressure;
        }
    }
}
