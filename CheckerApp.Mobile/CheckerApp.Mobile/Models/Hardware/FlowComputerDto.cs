using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class FlowComputerDto : ControllerDto
    {
        public FlowComputerDto()
        {
            HardwareType = HardwareType.FlowComputer;
        }
        public string CRC32 { get; set; }
        public long? LastConfigDate { get; set; }
    }
}
