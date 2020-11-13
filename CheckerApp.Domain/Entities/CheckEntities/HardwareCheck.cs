using CheckerApp.Domain.Entities.HardwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.CheckEntities
{
    public class HardwareCheck
    {
        public HardwareCheck()
        {
            CheckParameters = new HashSet<CheckParameter>();
        }

        public int Id { get; set; }
        public int HardwareId { get; set; }
        public virtual Hardware Hardware { get; set; }

        public virtual ICollection<CheckParameter> CheckParameters { get; private set; }
    }
}
