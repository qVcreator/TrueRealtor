using TrueRealtor.Data.Entities;

namespace TrueRealtor.Business.Interfaces;

public interface IAdminsService
{
    Task<int> AddApartment(Apartment apartment);
}
