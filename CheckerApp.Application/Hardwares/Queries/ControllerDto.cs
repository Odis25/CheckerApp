using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class ControllerDto : HardwareDto
    {
        public string DeviceModel { get; set; }
        public string AssemblyVersion { get; set; }
        public string IP { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Controller, ControllerDto>();
        }

    }
}
