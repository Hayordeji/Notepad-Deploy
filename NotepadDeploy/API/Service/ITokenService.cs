using API.Models;

namespace API.Service
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(AppUser user);
    }
}
