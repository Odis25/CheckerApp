using CheckerApp.Domain.Common;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Entities.SoftwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.ContractEntities
{
    public class Contract : AuditableEntity
    {
        public Contract()
        {
            HardwareList = new HashSet<Hardware>();
            SoftwareList = new HashSet<Software>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public bool HasProtocol { get; set; }

        public virtual ICollection<Hardware> HardwareList { get; private set; }
        public virtual ICollection<Software> SoftwareList { get; private set; }
    }
}
