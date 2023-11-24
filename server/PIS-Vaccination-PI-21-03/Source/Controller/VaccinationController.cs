using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;
namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class VaccinationController : ControllerBase
{
    [HttpPost]
    [ActionName("add-vaccination")]
    public async Task<IActionResult> AddVaccination([FromBody] VaccinationViewModel newVaccination) =>
        Ok(VaccinationRepository.CreateAsync(newVaccination));
    
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List() => Ok(VaccinationRepository.List());
    
    [HttpPut("{id}")] 
    [ActionName("delete-vaccination")]
    public async Task<IActionResult> DeleteVaccination([FromRoute] int id)
    {
        VaccinationRepository.Delete(id);
        return Ok();
    }
}