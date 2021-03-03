using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class InformPanelDto : HardwareDto
    {
        public InformPanelDto()
        {
            HardwareType = HardwareType.InformPanel;
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }

        public InformPanelType PanelType { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<InformPanel, InformPanelDto>();
        }
    }
}
