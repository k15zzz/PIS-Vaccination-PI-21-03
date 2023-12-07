using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]


public class OrganizationController : ControllerBase
{
    [HttpGet]
    [ActionName("read")]
    [CanPermission("read-organization")]
    public async Task<IActionResult> Read(int id)
    { 
        return Ok((OrganizationViewModel)OrganizationRepository.Read(id));
    }
    
    [HttpPost]
    [ActionName("create")]
    [CanPermission("create-organization")]
    public async Task<IActionResult> Create([FromBody] OrganizationViewModel newOrganization)
    {
        return Ok(OrganizationRepository.Create(newOrganization));
    }
    
    [HttpGet]
    [ActionName("list")]
    [CanPermission("read-organization")]
    public async Task<IActionResult> List()
    { 
        var list = OrganizationRepository.List();
        var result = new List<OrganizationViewModel>();

        foreach (var entitiesModel in list)
        {
            result.Add(entitiesModel);
        }
        
        return Ok(result);
    }
    
    [HttpPut] 
    [ActionName("update")]
    [CanPermission("update-organization")]
    public async Task<IActionResult> Update([FromBody] OrganizationViewModel organizationModel)
    { 
        return Ok((OrganizationViewModel)OrganizationRepository.Update(organizationModel));
    }
    
    [HttpDelete] 
    [ActionName("delete")]
    [CanPermission("delete-organization")]
    public async Task<IActionResult> Delete(int id)
    { 
        return Ok(OrganizationRepository.Delete(id));
    }
}