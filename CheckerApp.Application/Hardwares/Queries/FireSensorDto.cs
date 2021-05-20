using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class FireSensorDto : HardwareDto
    {
        public FireSensorDto()
        {
            HardwareType = Domain.Enums.HardwareType.FireSensor;
        }

        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<FireSensor, FireSensorDto>();
        }
    }
}
