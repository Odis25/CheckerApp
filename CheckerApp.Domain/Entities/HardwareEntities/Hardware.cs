using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public abstract class Hardware : AuditableEntity
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public HardwareType HardwareType { get; set; }
        public string Position { get; set; }
        public string SerialNumber { get; set; }

        public virtual HardwareCheck CheckResult { get; set; }   
    }
}
