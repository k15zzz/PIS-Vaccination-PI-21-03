using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]")]
public class AnimalController : ControllerBase
{
    [HttpGet]
    [ScopedPermission("read-animal")]
    public async Task<IActionResult> List()
    {
        using (AppDbContext db = new AppDbContext())
        {
            var animals = db
                .Animals
                .Include(a => a.Town)
                .ToList();
            
            return Ok(animals);
        }
    }
}