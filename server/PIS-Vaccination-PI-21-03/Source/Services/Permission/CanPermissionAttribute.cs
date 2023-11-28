using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PIS_Vaccination_PI_21_03.Source.Services.Authorize;

namespace PIS_Vaccination_PI_21_03.Source.Services.Permission;

public class CanPermissionAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _permission;

    public CanPermissionAttribute(string permission = null)
    {
        _permission = permission;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var jwtToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        
        if (jwtToken == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
        if (!AuthorizeService.ValidateToken(jwtToken))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwtToken);
        
        var idUser = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
        var nameUser = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        if (idUser == null || nameUser == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        int id;

        if (!int.TryParse(idUser, out id))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
        if (!PermissionService.CanPermission(id, _permission))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}