using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Mobile.Common.Enums
{
    public enum InformPanelType
    {
        [Display(Name = "Пожар")]
        Fire,
        [Display(Name = "Загазованность 1 порог")]
        Gas1,
        [Display(Name = "Загазованность 2 порог")]
        Gas2
    }
}
