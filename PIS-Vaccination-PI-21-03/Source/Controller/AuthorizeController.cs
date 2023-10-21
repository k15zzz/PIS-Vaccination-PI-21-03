using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PIS_Vaccination_PI_21_03.Source.Services.Authorize;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]")]
public class AuthorizeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Auth(string login, string password)
    {
        return Ok(AuthorizeService.LoginUser(login, password));
    }
}