using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.ContractEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public abstract class Hardware : AuditEntity
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public HardwareType HardwareType { get; set; }
        public string SerialNumber { get; set; }
        public Contract Contract { get; set; }
    }
}
