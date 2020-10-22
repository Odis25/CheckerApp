namespace CheckerApp.Shared.Models.Hardware
{
    public class FlowComputerVm : ControllerVm
    {
        public string CRC32 { get; set; }
        public long LastConfigDate { get; set; }
    }
}
