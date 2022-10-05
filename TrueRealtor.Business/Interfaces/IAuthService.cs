using TrueRealtor.Data.Entities;

namespace TrueRealtor.Business.Interfaces;

public interface IAuthService
{
    Task<string> GetToken(User user);
    Task<User> GetUserByLogin(string email, string password);
}
