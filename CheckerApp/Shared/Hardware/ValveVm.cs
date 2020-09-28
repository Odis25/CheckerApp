using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Hardware
{
    public class ValveVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public SignalType SignalType { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
