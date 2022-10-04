using Microsoft.AspNetCore.Authorization;
using TrueRealtor.Data.Enums;

namespace TrueRealtor.API.CustomAttributes;

public class AuthorizeByRoleAttribute : AuthorizeAttribute
{
    public AuthorizeByRoleAttribute(params Role[] roles)
    {
        Roles = string.Join(",", roles);
        Roles += $",{Role.Admin}";
    }
}
