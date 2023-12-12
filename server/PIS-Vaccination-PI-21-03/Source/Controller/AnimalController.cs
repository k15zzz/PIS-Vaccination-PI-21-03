using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class AnimalController : ControllerBase
{
    [HttpGet]
    [ActionName("read")]
    [CanPermission("read-animal")]
    public async Task<IActionResult> Read(int id)
    {
        return Ok((AnimalViewModel)AnimalRepository.Read(id));
    }
    
    [HttpPost]
    [ActionName("create")]
    [CanPermission("create-animal")]
    public async Task<IActionResult> Create([FromBody] AnimalViewModel newAnimal)
    {
        return Ok(AnimalRepository.Create(newAnimal));
    }

    [HttpGet]
    [ActionName("list")]
    // [Authorization] - если хочешь просто проверку авторизации по JWT токену
    // [CanPermission("read-animal")] - если хочешь проверку права по JWT токену
    [CanPermission("read-animal")]
    public async Task<IActionResult> List()
    { 
        var list = AnimalRepository.List();
        var result = new List<AnimalViewModel>();

        foreach (var animalEntities in list)
        {
            result.Add(animalEntities);
        }
        
        return Ok(result);
    }

    [HttpPut] 
    [ActionName("update")]
    [CanPermission("update-animal")]
    public async Task<IActionResult> Update([FromBody] AnimalViewModel animalModel)
    {
        return Ok((AnimalViewModel)AnimalRepository.Update(animalModel));
    }

    [HttpDelete]
    [ActionName("delete")]
    [CanPermission("delete-animal")]
    public async Task<IActionResult> Delete(int id)
    { 
        return Ok(AnimalRepository.Delete(id));
    }
}

