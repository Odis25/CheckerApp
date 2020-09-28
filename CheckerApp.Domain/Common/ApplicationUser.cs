using Microsoft.AspNetCore.Identity;

namespace CheckerApp.Domain.Common
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
