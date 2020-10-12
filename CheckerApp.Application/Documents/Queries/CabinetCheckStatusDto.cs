using AutoMapper;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Documents.Queries
{
    public class CabinetCheckStatusDto : HardwareCheckStatusDto
    {
        public CabinetVm Cabinet { get; set; }
        public bool HasProtocol { get; set; }
        public bool ColdStart { get; set; }
        public bool APC { get; set; }

        public string HasProtocolComment { get; set; }
        public string ColdStartComment { get; set; }
        public string APCComment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cabinet, CabinetCheckStatusDto>()
                .ForMember(dest => dest.Cabinet, m => m.MapFrom(src => src));
        }
    }

}
