using Microsoft.AspNetCore.Mvc;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]")]
public class TalksNonsenseController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SayHello(string name)
    {
        return Ok("Hello, World and " + name + "!");
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> SayNumber(long id)
    {
        return Ok(id);
    }
}