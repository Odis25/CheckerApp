namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public abstract class Controller : Hardware
    {
        public string DeviceModel { get; set; }
        public string AssemblyVersion { get; set; }
        public string IP { get; set; }       
    }
}
