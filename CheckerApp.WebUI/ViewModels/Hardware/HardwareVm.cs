using CheckerApp.WebUI.Enums;

namespace CheckerApp.WebUI.ViewModels
{
    public class HardwareVm
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public HardwareType HardwareType { get; set; }
        public string SerialNumber { get; set; }
    }
}