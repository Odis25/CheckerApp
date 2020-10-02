using Microsoft.AspNetCore.Identity;

namespace CheckerApp.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
