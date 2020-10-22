using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.CheckEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.Documents
{
    public class ContractCheck : AuditableEntity
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public virtual IEnumerable<HardwareCheck> HardwareChecks { get; set; }
    }
}
