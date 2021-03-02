using AutoMapper;
using CheckerApp.Domain.Entities.SoftwareEntities;

namespace CheckerApp.Application.Softwares.Queries.GetSoftwaresList
{
    public class ScadaDto: SoftwareDto
    {
        public ScadaDto()
        {
            SoftwareType = Domain.Enums.SoftwareType.SCADA;
        }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<SCADA, ScadaDto>();
        }
    }
}
