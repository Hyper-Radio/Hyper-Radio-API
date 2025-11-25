using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(Admin admin);
    }
}
