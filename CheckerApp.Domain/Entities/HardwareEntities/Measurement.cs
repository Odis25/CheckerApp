using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public abstract class Measurement : Hardware
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }        
        public string EU { get; set; }
        public SignalType SignalType { get; set; }
    }
}
