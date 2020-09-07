namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class ControllerVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string AssemblyVersion { get; set; }
        public string IP { get; set; }
        public string CRC32 { get; set; }
        public ulong LastConfigDate { get; set; }
    }
}
