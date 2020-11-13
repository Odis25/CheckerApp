using CheckerApp.Domain.Entities.SoftwareEntities;
using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.CheckEntities
{
    public class SoftwareCheck
    {
        public SoftwareCheck()
        {
            CheckParameters = new HashSet<CheckParameter>();
        }

        public int Id { get; set; }
        public int SoftwareId { get; set; }
        public virtual Software Software { get; set; }

        public virtual ICollection<CheckParameter> CheckParameters { get; private set; }
    }
}
