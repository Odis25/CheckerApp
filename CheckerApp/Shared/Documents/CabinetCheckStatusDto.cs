using CheckerApp.Shared.Hardware;

namespace CheckerApp.Shared.Documents
{
    public class CabinetCheckStatusDto : HardwareCheckStatusDto
    {
        public CabinetVm Cabinet { get; set; }
        public bool HasProtocol { get; set; }
        public bool ColdStart { get; set; }
        public bool APC { get; set; }

        public string HasProtocolComment { get; set; }
        public string ColdStartComment { get; set; }
        public string APCComment { get; set; }
    }
}
