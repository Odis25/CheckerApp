using System.Collections.Generic;
using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class NetworkHardwareDto : HardwareDto
    {
        public NetworkHardwareDto()
        {
            NetworkDevices = new HashSet<NetworkDeviceDto>();
            HardwareType = HardwareType.Network;
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
