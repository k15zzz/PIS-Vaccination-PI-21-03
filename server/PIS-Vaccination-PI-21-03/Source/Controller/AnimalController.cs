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
    public async Task<IActionResult> AddAnimal([FromBody] AnimalEntitiesModel newAnimal) =>
        Ok(new AnimalRepository().CreateAsync(newAnimal));
    [HttpGet]
    // [ScopedPermission("read-animal")]
    [ActionName("list")]
    public async Task<IActionResult> List() => Ok(new AnimalRepository().ReadTableAsync());

    [HttpPut("{id}")] [ActionName("update-animal")]
    public async Task<IActionResult> UpdateAnimal([FromBody] JsonContent animalModel, [FromRoute] int id)
    {
        new AnimalRepository().UpdateAsync(id, animalModel);
        return Ok();
    }
    
}

