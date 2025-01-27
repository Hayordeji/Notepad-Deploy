using API.Models;

namespace API.Service
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
