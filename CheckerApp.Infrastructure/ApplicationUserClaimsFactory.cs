using CheckerApp.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CheckerApp.Infrastructure
{
    public class ApplicationUserClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaimsFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            if (!string.IsNullOrWhiteSpace(user.FullName))
                identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;
        }
    }
}
