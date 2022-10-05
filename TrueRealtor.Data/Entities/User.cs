using TrueRealtor.Data.Enums;

namespace TrueRealtor.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Status Status { get; set; }
}
