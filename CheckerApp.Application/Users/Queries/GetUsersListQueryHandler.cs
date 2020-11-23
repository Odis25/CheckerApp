using CheckerApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Users.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUsersListQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UsersListDto> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();

            var model = new UsersListDto();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    AccountName = user.UserName,
                    FullName = user.FullName,
                    Role = (await _userManager.GetRolesAsync(user)).First()
                };
                model.Users.Add(userDto);
            }

            return model;
        }
    }
}
