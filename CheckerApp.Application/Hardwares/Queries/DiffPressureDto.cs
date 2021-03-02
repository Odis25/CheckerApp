using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class DiffPressureDto : MeasurementDto
    {
        public DiffPressureDto()
        {
            HardwareType = Domain.Enums.HardwareType.DiffPressure;
        }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<DiffPressure, DiffPressureDto>();
        }
    }
}
