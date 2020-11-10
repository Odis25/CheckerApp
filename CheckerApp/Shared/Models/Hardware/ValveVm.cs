using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class ValveVm : HardwareVm
    {
        public ValveVm()
        {
            HardwareType = HardwareType.Valve;
        }

        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public SignalType SignalType { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
