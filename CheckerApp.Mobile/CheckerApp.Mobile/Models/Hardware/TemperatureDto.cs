using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class TemperatureDto : MeasurementDto
    {
        public TemperatureDto()
        {
            HardwareType = HardwareType.Temperature;
        }
    }
}
