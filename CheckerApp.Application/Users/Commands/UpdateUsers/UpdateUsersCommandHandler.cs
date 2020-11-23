using CheckerApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUsersCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            foreach (var user in request.Users.Users)
            {
                var appUser = await _userManager.FindByIdAsync(user.Id);
                var roles = await _userManager.GetRolesAsync(appUser);
                await _userManager.RemoveFromRolesAsync(appUser, roles);
                await _userManager.AddToRoleAsync(appUser, user.Role);
            }

            return Unit.Value;
        }
    }
}
