using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using PIS_Vaccination_PI_21_03.Source.Services.Authorize;

namespace PIS_Vaccination_PI_21_03.Source.Services.Permission;

public class AuthorizationAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (authHeader == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!AuthorizeService.ValidateToken(authHeader))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}