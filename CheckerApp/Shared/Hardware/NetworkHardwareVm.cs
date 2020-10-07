using System.Collections.Generic;

namespace CheckerApp.Shared.Hardware
{
    public class NetworkHardwareVm : HardwareVm
    {
        public NetworkHardwareVm()
        {
            NetworkDevices = new HashSet<NetworkDeviceDto>();
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string Mask { get; set; }
        public ICollection<NetworkDeviceDto> NetworkDevices { get; set; }
    }
    public class NetworkDeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string MacAddress { get; set; }
    }
}
