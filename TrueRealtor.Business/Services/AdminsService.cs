using TrueRealtor.Business.Interfaces;
using TrueRealtor.Data.Entities;
using TrueRealtor.Data.Interfaces;

namespace TrueRealtor.Business.Services;

public class AdminsService : IAdminsService
{
    private readonly IAdminsRepository _adminsRepository;

    public AdminsService(IAdminsRepository adminsRepository)
    {
        _adminsRepository = adminsRepository;
    }

    public async Task<int> AddApartment(Apartment apartment)
    {
        //Add checking on existing similar item
        var result = await _adminsRepository.AddApartment(apartment);

        return result;
    }
}
