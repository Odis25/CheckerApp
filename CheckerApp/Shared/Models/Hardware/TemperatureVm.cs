using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class TemperatureVm : MeasurementVm
    {
        public TemperatureVm()
        {
            HardwareType = HardwareType.Temperature;
        }
    }
}
