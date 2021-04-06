namespace CheckerApp.Mobile.Models.Hardware
{
    public class ControllerDto : HardwareDto
    {
        public string DeviceModel { get; set; }
        public string AssemblyVersion { get; set; }
        public string IP { get; set; }
    }
}
