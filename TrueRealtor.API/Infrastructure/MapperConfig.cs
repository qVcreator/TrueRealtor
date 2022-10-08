using AutoMapper;
using TrueRealtor.API.Requests;
using TrueRealtor.Data.Entities;

namespace TrueRealtor.API.Infrastructure;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ApartmentRequest, Apartment>();
        CreateMap<UpdateApartmentRequest, Apartment>();
    }
}
