using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class HardwareDto : IMapFrom<Hardware>
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string SerialNumber { get; set; }
        public HardwareType HardwareType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hardware, HardwareDto>().IncludeAllDerived();
        }
    }
}
