using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Documents.Queries
{
    public class HardwareCheckStatusDto : IMapFrom<Hardware>
    {
        public HardwareType HardwareType { get; set; }
    }
}