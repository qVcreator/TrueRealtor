using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrueRealtor.API.CustomAttributes;
using TrueRealtor.API.Extensions;
using TrueRealtor.API.Requests;
using TrueRealtor.Business.Interfaces;
using TrueRealtor.Data.Entities;

namespace TrueRealtor.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AdminsController : Controller
{
    private readonly IAdminsService _adminsService;
    private readonly IMapper _mapper;

    public AdminsController(IAdminsService adminsService, IMapper mapper)
    {
        _adminsService = adminsService;
        _mapper = mapper;
    }

    [HttpPost]
    [AuthorizeByRole]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> AddApartment([FromBody] ApartmentRequest apartmentToAdd)
    {
        var result = await _adminsService.AddApartment(_mapper.Map<Apartment>(apartmentToAdd));
        return Created($"{this.GetUri()}/{result}", result);
    }
}
