using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class HardwareVm
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string SerialNumber { get; set; }
        public HardwareType HardwareType { get; set; }
    }
}
