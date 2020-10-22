using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Entities.HardwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries
{
    public class HardwareCheckDto : IMapFrom<Hardware>
    {
        public HardwareCheckDto()
        {
            CheckParameters = new HashSet<CheckParameterDto>();
        }

        public HardwareVm Hardware { get; set; }
        public IEnumerable<CheckParameterDto> CheckParameters { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hardware, HardwareCheckDto>()
                .ForMember(dest => dest.Hardware, m => m.MapFrom(src => src));
        }
    }
}