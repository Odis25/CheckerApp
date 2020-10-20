using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Entities.HardwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Documents.Queries
{
    public class HardwareCheckStatusDto : IMapFrom<Hardware>
    {
        public HardwareCheckStatusDto()
        {
            CheckParameters = new HashSet<CheckParameter>();
        }

        public HardwareVm Device { get; set; }
        public ICollection<CheckParameter> CheckParameters { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hardware, HardwareCheckStatusDto>()
                .ForMember(dest => dest.Device, m => m.MapFrom(src => src));
        }
    }
}