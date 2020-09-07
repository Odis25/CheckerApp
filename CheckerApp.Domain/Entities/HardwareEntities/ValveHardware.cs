namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class ValveHardware : Hardware
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public RS485Settings Settings { get; set; }
    }
}
