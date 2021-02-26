using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class GasAnalyzerVm : MeasurementVm
    {
        public GasAnalyzerVm()
        {
            HardwareType = HardwareType.GasAnalyzer;
        }
    }
}
