using TrueRealtor.Business.Interfaces;
using TrueRealtor.Data.Entities;

namespace TrueRealtor.Business.Services;

public class AuthService : IAuthService
{
    public Task<string> GetToken(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByLogin(string email, string password)
    {
        throw new NotImplementedException();
    }
}
