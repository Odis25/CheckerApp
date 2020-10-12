namespace CheckerApp.Domain.Entities.Documents
{
    public class CabinetCheckStatus
    {       

        public bool HasProtocol { get; set; }
        public bool ColdStart { get; set; }
        public bool APC { get; set; }

        public string HasProtocolComment { get; set; }
        public string ColdStartComment { get; set; }
        public string APCComment { get; set; }
    }
}
