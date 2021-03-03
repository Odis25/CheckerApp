using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class InformPanelVm : HardwareVm
    {
        public InformPanelVm()
        {
            HardwareType = HardwareType.InformPanel;
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }

        public InformPanelType PanelType { get; set; }
    }
}
