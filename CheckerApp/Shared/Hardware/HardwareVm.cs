using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Hardware
{
    public class HardwareVm
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string SerialNumber { get; set; }
        public HardwareType HardwareType { get; set; }
    }
}
