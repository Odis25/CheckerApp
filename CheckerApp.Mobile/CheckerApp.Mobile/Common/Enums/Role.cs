using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Mobile.Common.Enums
{
    public enum Role
    {
        [Display(Name = "Пользователь")]
        User,
        [Display(Name = "Проверяющий")]
        SuperUser,
        [Display(Name = "Администратор")]
        Admin
    }
}
