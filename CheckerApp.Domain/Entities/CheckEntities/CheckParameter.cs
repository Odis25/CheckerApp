using System;

namespace CheckerApp.Domain.Entities.CheckEntities
{
    public class CheckParameter
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Method { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        //public int HardwareCheckId { get; set; }
        //public virtual HardwareCheck HardwareCheck { get; set; }
        //public virtual SoftwareCheck SoftwareCheck { get; set; }
    }
}
