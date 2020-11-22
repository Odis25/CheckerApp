using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Domain.Enums
{
    public enum SoftwareType
    {
        [Display(Name = "SCADA-система")]
        SCADA,
        [Display(Name = "Дополнительное ПО")]
        Other
    }
}
