using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class AnimalController : ControllerBase
{
    [HttpGet]
    [ActionName("read")]
    public async Task<IActionResult> Read(int id)
    {
        return Ok((AnimalViewModel)AnimalRepository.Read(id));
    }
    
    [HttpPost]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] AnimalViewModel newAnimal)
    {
        return Ok(AnimalRepository.Create(newAnimal));
    }

    [HttpGet]
    // [ScopedPermission("read-animal")]
    [ActionName("list")]
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
    public async Task<IActionResult> Update([FromBody] AnimalViewModel animalModel)
    {
        return Ok((AnimalViewModel)AnimalRepository.Update(animalModel));
    }

    [HttpDelete]
    [ActionName("delete")]
    public async Task<IActionResult> Delete(int id)
    { 
        return Ok(AnimalRepository.Delete(id));
    }
}

