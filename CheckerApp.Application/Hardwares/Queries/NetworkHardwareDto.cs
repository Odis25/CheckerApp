using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class NetworkHardwareDto : HardwareDto
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string Mask { get; set; }
        public ICollection<NetworkDeviceDto> NetworkDevices { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<NetworkHardware, NetworkHardwareDto>();
        }
    }
}

