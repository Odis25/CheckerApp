using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class DiffPressureDto : MeasurementDto
    {
        public DiffPressureDto()
        {
            HardwareType = HardwareType.DiffPressure;
        }
    }
}
