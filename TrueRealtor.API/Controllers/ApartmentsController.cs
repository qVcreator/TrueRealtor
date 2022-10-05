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
public class ApartmentsController : Controller
{
    private readonly IApartmentsService _apartmentsService;
    private readonly IMapper _mapper;

    public ApartmentsController(IApartmentsService apartmentsService, IMapper mapper)
    {
        _apartmentsService = apartmentsService;
        _mapper = mapper;
    }

    [HttpPost]
    //[AuthorizeByRole] (Temporarily disabled)
    [AllowAnonymous]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> AddApartment([FromBody] ApartmentRequest apartmentToAdd)
    {
        var result = await _apartmentsService.AddApartment(_mapper.Map<Apartment>(apartmentToAdd));
        return Created($"{this.GetUri()}/{result}", result);
    }

    [HttpPut("{id}")]
    //[AuthorizeByRole]
    [AllowAnonymous]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> UpdateApartment([FromRoute] int id, [FromBody] UpdateApartmentRequest apartmentToUpdate)
    {
        await _apartmentsService.UpdateAppartment(id, _mapper.Map<Apartment>(apartmentToUpdate));
        return NoContent();
    }

}
