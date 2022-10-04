using TrueRealtor.Data.Entities;

namespace TrueRealtor.Data.Interfaces;

public interface IAdminsRepository
{
    Task<int> AddApartment(Apartment apartment);
}
