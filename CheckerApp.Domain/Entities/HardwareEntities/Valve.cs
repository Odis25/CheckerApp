using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class Valve : Hardware
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public SignalType SignalType { get; set; }
        public virtual ModbusSettings Settings { get; set; }
    }
}
