using CheckerApp.Application.Users.Queries;
using MediatR;

namespace CheckerApp.Application.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommand : IRequest
    {
        public UsersListDto Users { get; set; }
    }
}
