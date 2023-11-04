using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Repository;
namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]

public class VaccinationController : ControllerBase
{
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List() => Ok(new VaccinationRepository().ReadTableAsync());
}