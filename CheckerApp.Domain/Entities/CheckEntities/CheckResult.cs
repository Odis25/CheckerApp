using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.ContractEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.Documents
{
    public class CheckResult : AuditableEntity
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual IEnumerable<HardwareCheck> HardwareChecks { get; set; }
    }
}
