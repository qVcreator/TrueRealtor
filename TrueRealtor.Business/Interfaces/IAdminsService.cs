using TrueRealtor.Data.Entities;

namespace TrueRealtor.Business.Interfaces;

public interface IAdminsService
{
    Task<int> AddAdmin(User user);
    Task<int> AddManager(User user);
    Task<User> GetUserByEmail(string email);
}
