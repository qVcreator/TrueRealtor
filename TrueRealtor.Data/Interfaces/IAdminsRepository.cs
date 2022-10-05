using TrueRealtor.Data.Entities;

namespace TrueRealtor.Data.Interfaces;

public interface IAdminsRepository
{
    Task<int> AddAdmin(User user);
    Task<int> AddManager(User user);
    Task<User> GetUserByEmail(string email);

} 
