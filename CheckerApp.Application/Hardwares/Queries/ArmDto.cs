using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class ArmDto : HardwareDto
    {
        public string Name { get; set; }
        public string Monitor { get; set; }
        public string MonitorSN { get; set; }
        public string Keyboard { get; set; }
        public string KeyboardSN { get; set; }
        public string Mouse { get; set; }
        public string MouseSN { get; set; }
        public bool HasRAID { get; set; }

        public string OS { get; set; }
        public string ProductKeyOS { get; set; }

        public ICollection<NetworkAdapterDto> NetworkAdapters { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<ARM, ArmDto>();
        }
    }
}
