using System.Collections.Generic;

namespace CheckerApp.Shared.Models.Users
{
    public class UsersListVm
    {
        public ICollection<UserDto> Users { get; set; }
    }
}
