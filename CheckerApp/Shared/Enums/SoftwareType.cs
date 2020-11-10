using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Shared.Enums
{
    public enum SoftwareType
    {
        [Display(Name = "SCADA-система")]
        SCADA,
        [Display(Name = "Другое ПО")]
        Other
    }
}
