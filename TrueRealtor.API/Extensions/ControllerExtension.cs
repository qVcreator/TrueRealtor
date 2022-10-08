using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TrueRealtor.API.Extensions;

public static class ControllerExtension
{
    public static string GetUri(this Controller controller) =>
        $"{controller.Request?.Scheme}://{controller.Request?.Host.Value}{controller.Request?.Path.Value}";

    public static int? GetUserId(this Controller controller)
    {
        if (controller.HttpContext.User.Identity is not ClaimsIdentity identity)
            return null;

        if (!int.TryParse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            return null;

        return userId;
    }
}
