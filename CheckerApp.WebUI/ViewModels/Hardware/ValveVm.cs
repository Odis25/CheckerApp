namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class ValveVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public ModbusSettingsVm Settings { get; set; }
    }
}
