namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class FireSensor : Hardware
    {
        public FireSensor()
        {            
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
    }
}
