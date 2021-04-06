using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class PressureDto : MeasurementDto
    {
        public PressureDto()
        {
            HardwareType = HardwareType.Pressure;
        }
    }
}
