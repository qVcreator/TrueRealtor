using TrueRealtor.Data.Entities;
using TrueRealtor.Data.Interfaces;

namespace TrueRealtor.Data.Repositories;

public class AdminsRepository : IAdminsRepository
{
    private readonly TrueRealtorContext _context;

    public AdminsRepository(TrueRealtorContext context)
    {
        _context = context;
    }

    public async Task<int> AddApartment(Apartment apartment)
    {
        await _context.AddAsync(apartment);
        await _context.SaveChangesAsync();

        return apartment.Id;
    }
}
