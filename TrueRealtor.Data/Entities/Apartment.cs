using TrueRealtor.Data.Enums;

namespace TrueRealtor.Data.Entities;

public class Apartment
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int CityId { get; set; }
    public byte RoomCount { get; set; }
    public string Address { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdate { get; set; }
    public Status Status { get; set; }
}
