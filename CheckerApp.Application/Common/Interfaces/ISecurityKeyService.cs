using Microsoft.IdentityModel.Tokens;

namespace CheckerApp.Application.Common.Interfaces
{
    public interface ISecurityKeyService
    {
        string SigningAlgorithm { get; }

        SecurityKey GetKey();
    }
}
