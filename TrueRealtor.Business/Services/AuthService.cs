using TrueRealtor.Business.Infrastructure;
using TrueRealtor.Business.Interfaces;
using TrueRealtor.Data.Entities;
using TrueRealtor.Data.Enums;

namespace TrueRealtor.Business.Services;

public class AuthService : IAuthService
{
    private readonly IAdminsService _adminsService;

    public AuthService(IAdminsService adminsService)
    {
        _adminsService = adminsService;
    }
    public Task<string> GetToken(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByLogin(string email, string password)
    {
        var result = new User();

        var user = await _adminsService.GetUserByEmail(email);

        if (user == null)
            throw new Exception();// custom later

        if (user is not null && email == user.Email &&
            Hash.ValidatePassword(password, user.Password))
        {
            result.Email = email;
            result.Role = user.Role;
            result.Id = user.Id;
        }

        return result;
    }
}
