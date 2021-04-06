using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware 
{ 
    public class MeasurementDto : HardwareDto
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string EU { get; set; }
        public SignalType SignalType { get; set; }
    }
}
