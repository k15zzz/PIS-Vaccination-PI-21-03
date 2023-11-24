using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Services.Authorize;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

public class AuthRequest
{
    public string Login { get; set; }
    public string Password { get; set; } 
}

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class AuthorizeController : ControllerBase
{
    [HttpPost]
    [ActionName("auth")]
    public async Task<IActionResult> Auth([FromBody] AuthRequest request)
    {
        return Ok(AuthorizeService.LoginUser(request.Login, request.Password));
    }
}