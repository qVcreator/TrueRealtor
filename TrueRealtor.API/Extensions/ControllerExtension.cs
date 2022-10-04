using Microsoft.AspNetCore.Mvc;

namespace TrueRealtor.API.Extensions;

public static class ControllerExtension
{
    public static string GetUri(this Controller c) =>
        $"{c.Request?.Scheme}://{c.Request?.Host.Value}{c.Request?.Path.Value}";
}
