using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Shared.Enums
{
    public enum SoftwareType
    {
        [Display(Name = "SCADA-система")]
        SCADA,
        [Display(Name = "Дополнительное ПО")]
        Other
    }
}
