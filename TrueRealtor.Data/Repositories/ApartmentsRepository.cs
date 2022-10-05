using Microsoft.EntityFrameworkCore;
using TrueRealtor.Data.Entities;
using TrueRealtor.Data.Interfaces;

namespace TrueRealtor.Data.Repositories;

public class ApartmentsRepository : IApartmentsRepository
{
    private readonly TrueRealtorContext _context;

    public ApartmentsRepository(TrueRealtorContext context)
    {
        _context = context;
    }

    public async Task<int> AddApartment(Apartment apartment)
    {
        await _context.AddAsync(apartment);
        await _context.SaveChangesAsync();

        return apartment.Id;
    }

    public async Task<Apartment?> GetApartmentById(int id) =>
        await _context.Apartments.FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateApartment(Apartment apartment)
    {
        _context.Apartments.Update(apartment);
        await _context.SaveChangesAsync();
    }
}
