using TrueRealtor.Business.Interfaces;
using TrueRealtor.Data.Entities;
using TrueRealtor.Data.Interfaces;

namespace TrueRealtor.Business.Services;

public class ApartmentsService : IApartmentsService
{
    private readonly IApartmentsRepository _apartmentsRepository;

    public ApartmentsService(IApartmentsRepository adminsRepository)
    {
        _apartmentsRepository = adminsRepository;
    }

    public async Task<int> AddApartment(Apartment apartment)
    {
        //Add checking on existing similar item?
        apartment.DateCreated = DateTime.Now;

        var result = await _apartmentsRepository.AddApartment(apartment);

        return result;
    }

    public async Task UpdateAppartment(int id, Apartment apartment)
    {
        var apartmentToUpdate = await _apartmentsRepository.GetApartmentById(id);

        if (apartmentToUpdate is null)
            throw new Exception();// later custom exception

        apartmentToUpdate.DateUpdate = DateTime.Now;
        apartmentToUpdate.Status = apartment.Status;
        apartmentToUpdate.Address = apartment.Address;
        apartmentToUpdate.Price = apartment.Price;
        apartmentToUpdate.CityId = apartment.CityId;
        apartmentToUpdate.RoomCount = apartment.RoomCount;

        await _apartmentsRepository.UpdateApartment(apartmentToUpdate);
    }
}
