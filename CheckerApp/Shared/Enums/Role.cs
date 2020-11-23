using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Shared.Enums
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
