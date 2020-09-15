using CheckerApp.WebUI.Enums;

namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class ValveVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public SignalType SignalType { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
