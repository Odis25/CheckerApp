using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.DTOs
{
    public class MeasurementHardwareVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string EU { get; set; }
        public SignalType SignalType { get; set; }
    }
}
