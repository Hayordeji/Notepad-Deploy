using API.DTO.Account;

namespace API.Service
{
    public interface IAuthService
    {
        Task<bool> RegisterAccount(RegisterDto registerData);
    }
}
