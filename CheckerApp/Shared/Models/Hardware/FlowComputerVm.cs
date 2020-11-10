using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class FlowComputerVm : ControllerVm
    {
        public FlowComputerVm()
        {
            HardwareType = HardwareType.FlowComputer;
        }
        public string CRC32 { get; set; }
        public long LastConfigDate { get; set; }
    }
}
