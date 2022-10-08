using TrueRealtor.Data.Entities;

namespace TrueRealtor.Business.Interfaces;

public interface IApartmentsService
{
    Task<int> AddApartment(Apartment apartment);

    Task UpdateAppartment(int idAppartment, Apartment apartment);
}
