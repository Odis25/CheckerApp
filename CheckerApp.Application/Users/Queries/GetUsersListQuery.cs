using MediatR;

namespace CheckerApp.Application.Users.Queries
{
    public class GetUsersListQuery : IRequest<UsersListDto>
    {
    }
}
