using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]

public class ContractController : ControllerBase
{
    [HttpPost]
    [ActionName("add-contract")]
    public async Task<IActionResult> AddContract(ContractEntitiesModel newContract) =>
        Ok(new ContractRepository().CreateAsync(newContract));
    
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List() => Ok(new ContractRepository().ReadTableAsync());
}