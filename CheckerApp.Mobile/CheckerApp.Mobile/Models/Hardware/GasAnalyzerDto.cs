using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class GasAnalyzerDto : MeasurementDto
    {
        public GasAnalyzerDto()
        {
            HardwareType = HardwareType.GasAnalyzer;
        }
    }
}
