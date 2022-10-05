using Microsoft.AspNetCore.Mvc;
using TrueRealtor.API.Extensions;
using TrueRealtor.API.Requests;
using TrueRealtor.Business.Interfaces;

namespace TrueRealtor.API.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<string>> Login(LoginRequest authParams)
    {
        var user = await _authService.GetUserByLogin(authParams.Email, authParams.Password);

        if(user == null)
            return Unauthorized();

        var userId = this.GetUserId();

        if (userId is not null && userId.Value != user.Id)
            return Forbid();

        return await _authService.GetToken(user);
    }
}
