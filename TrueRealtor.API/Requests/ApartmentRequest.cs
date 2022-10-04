using TrueRealtor.Data.Enums;

namespace TrueRealtor.API.Requests;

public class ApartmentRequest
{
    public decimal Price { get; set; }
    public int CityId { get; set; }
    public string Info { get; set; }
    public Status Status { get; set; }
}
