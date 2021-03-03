using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class InformPanel : Hardware
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }

        public InformPanelType PanelType { get; set; }
    }
}
