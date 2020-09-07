using CheckerApp.Domain.Common;
using System.Collections.Generic;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Domain.Entities.ContractEntities
{
    public class Contract : AuditEntity
    {
        public Contract()
        {
            HardwareList = new List<Hardware>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }

        public IList<Hardware> HardwareList { get; }
    }
}
