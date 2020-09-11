namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class FlowComputer : Controller
    {
        public string CRC32 { get; set; }
        public ulong? LastConfigDate { get; set; }
    }
}
