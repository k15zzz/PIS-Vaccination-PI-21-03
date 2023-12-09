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
        => Ok(await AnimalRepository.Read(id));

    [HttpPost]
    [ActionName("create")]
    [CanPermission("create-animal")]
    public async Task<IActionResult> Create([FromBody] AnimalViewModel newAnimal)
        => Ok(await AnimalRepository.Create(newAnimal));

    [HttpGet]
    [ActionName("list")]
    // [Authorization] - если хочешь просто проверку авторизации по JWT токену
    // [CanPermission("read-animal")] - если хочешь проверку права по JWT токену
    [CanPermission("read-animal")]
    public async Task<IActionResult> List()
        => Ok((await AnimalRepository.List())
            .Select(x =>
        {
            if (x == null) throw new ArgumentNullException();
                return (AnimalViewModel)x;
        })
            .ToList());

    [HttpPut]
    [ActionName("update")]
    [CanPermission("update-animal")]
    public async Task<IActionResult> Update([FromBody] AnimalViewModel animalModel)
        => Ok((AnimalViewModel)await AnimalRepository.Update(animalModel));

    [HttpDelete]
    [ActionName("delete")]
    [CanPermission("delete-animal")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await AnimalRepository.Delete(id));
}