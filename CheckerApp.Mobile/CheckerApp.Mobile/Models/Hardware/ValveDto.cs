using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class ValveDto : HardwareDto
    {
        public ValveDto()
        {
            HardwareType = HardwareType.Valve;
        }

        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public SignalType SignalType { get; set; }
        public ModbusSettingsDto ModbusSettings { get; set; }
    }
}
