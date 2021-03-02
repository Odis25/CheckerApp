using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class GasAnalyzerDto : MeasurementDto
    {
        public GasAnalyzerDto()
        {
            HardwareType = Domain.Enums.HardwareType.GasAnalyzer;
        }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<GasAnalyzer, GasAnalyzerDto>();
        }
    }
}
