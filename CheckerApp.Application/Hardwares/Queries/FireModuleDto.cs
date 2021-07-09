using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class FireModuleDto : HardwareDto
    {
        public FireModuleDto()
        {
            HardwareType = Domain.Enums.HardwareType.FireModule;
        }

        public string DeviceType { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<FireModule, FireModuleDto>();
        }
    }
}
