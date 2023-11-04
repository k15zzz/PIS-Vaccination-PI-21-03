using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [ActionName("sey-hello")]
    public async Task<IActionResult> Hello()
    {
        return Ok("hello Ульяна и Паша");
    }
}