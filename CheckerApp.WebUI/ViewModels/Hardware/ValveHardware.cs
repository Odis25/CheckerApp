namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class ValveHardware : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public RS485Settings Settings { get; set; }
    }
}
