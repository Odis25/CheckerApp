using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class InformPanel : Hardware
    {
        public InformPanelType PanelType { get; set; }
    }
}
