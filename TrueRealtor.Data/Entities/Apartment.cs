namespace TrueRealtor.Data.Entities;

public class Apartment
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int CityId { get; set; }
    public string Address { get; set; }
}
