using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class NetworkHardware : Hardware
    {
        public NetworkHardware()
        {
            NetworkDevices = new HashSet<NetworkDevice>();
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string Mask { get; set; }
        public virtual ICollection<NetworkDevice> NetworkDevices { get; private set; }
    }

    public class NetworkDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string MacAddress { get; set; }
    }
}
