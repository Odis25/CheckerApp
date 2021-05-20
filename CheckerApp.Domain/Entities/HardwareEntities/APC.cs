namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class APC : Hardware
    {
        public APC()
        {
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
    }
}
