using CheckerApp.Shared.Models.Commands;
using CheckerApp.Shared.Models.Users;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Client.Pages
{
    public partial class Users
    {
        [Inject] HttpClient HttpClient { get; set; }
        UsersListVm UsersList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UsersList = await HttpClient.GetFromJsonAsync<UsersListVm>("api/users");
        }

        private async Task SaveChanges()
        {
            var command = new UpdateUsersCommandVm { Users = UsersList };

            await HttpClient.PutJsonAsync<UpdateUsersCommandVm>("api/users", command);
        }
    }
}
