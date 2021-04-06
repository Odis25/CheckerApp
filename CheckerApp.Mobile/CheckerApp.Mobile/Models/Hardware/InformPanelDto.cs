using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
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
    }
}
