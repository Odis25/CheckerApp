using CheckerApp.Domain.Entities.ContractEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.Documents
{
    public class ContractCheckStatus
    {
        public ContractCheckStatus()
        {
            HardwareChecks = new HashSet<HardwareCheckStatus>();
        }
        public int Id { get; set; }
        public Contract Contract { get; set; }
        public virtual ICollection<HardwareCheckStatus> HardwareChecks { get; set; }
    }
}
