using CheckerApp.WebUI.Enums;

namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class MeasurementVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string EU { get; set; }
        public SignalType SignalType { get; set; }
    }
}
