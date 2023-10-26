using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class AnimalController : ControllerBase
{
    [HttpGet]
    // [ScopedPermission("read-animal")]
    [ActionName("list")]
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