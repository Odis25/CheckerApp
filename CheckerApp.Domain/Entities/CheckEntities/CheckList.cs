using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.ContractEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.Documents
{
    public class CheckList : AuditableEntity
    {
        public CheckList()
        {
            HardwareChecks = new HashSet<HardwareCheck>();
            SoftwareChecks = new HashSet<SoftwareCheck>();
        }
        public int Id { get; set; }
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        public virtual ICollection<HardwareCheck> HardwareChecks { get; private set; }
        public virtual ICollection<SoftwareCheck> SoftwareChecks { get; private set; }
    }
}
