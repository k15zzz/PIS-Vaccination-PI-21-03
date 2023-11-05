using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class AnimalController : ControllerBase
{
    [HttpPost]
    [ActionName("add-animal")]
    public async Task<IActionResult> AddAnimal(AnimalEntitiesModel newAnimal) =>
        Ok(new AnimalRepository().CreateAsync(newAnimal));
    // я не уверен что так правильно, простите, потом поменяю если ето неправильно
    [HttpGet]
    // [ScopedPermission("read-animal")]
    [ActionName("list")]
    public async Task<IActionResult> List() => Ok(new AnimalRepository().ReadTableAsync());
    
}

