using System.Collections.Generic;

namespace CheckerApp.Application.Users.Queries
{
    public class UsersListDto
    {
        public UsersListDto()
        {
            Users = new HashSet<UserDto>();
        }

        public ICollection<UserDto> Users { get; set; }
    }
}
