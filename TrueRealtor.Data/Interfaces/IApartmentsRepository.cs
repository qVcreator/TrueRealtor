using TrueRealtor.Data.Entities;

namespace TrueRealtor.Data.Interfaces;

public interface IApartmentsRepository
{
    Task<int> AddApartment(Apartment apartment);
    Task<Apartment?> GetApartmentById(int id);
    Task UpdateApartment(Apartment apartment);
}
