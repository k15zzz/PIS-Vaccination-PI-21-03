using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Models.DTOModels;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;
using PIS_Vaccination_PI_21_03.Source.Services.Statistic;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class StatisticController: ControllerBase
{
    [HttpPost]
    [ActionName("make")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> MakeReport([FromBody] ReportRequestDTO request)
    {
        try 
        {
            var report = StatisticService.MakeReport(request.DateStar, request.DateFinish, request.Towns);
            return Ok(report); 
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    [HttpGet]
    [ActionName("list")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> List()
    {
        var list = StatisticRepository.List();
        var result = new List<StatisticViewModel>();

        foreach (var animalEntities in list)
        {
            result.Add(animalEntities);
        }
        
        return Ok(result);
    }
    
    [HttpPost]
    [ActionName("create")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> Create([FromBody] StatisticViewModel newAnimal)
    {
        return Ok(StatisticRepository.Create(newAnimal));
    } 
    
    [HttpGet]
    [ActionName("read")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> Read(int id)
    {
        return Ok((StatisticViewModel)StatisticRepository.Read(id));
    }
    
    [HttpPut] 
    [ActionName("update")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> Update([FromBody] StatisticViewModel animalModel)
    {
        return Ok((StatisticViewModel)StatisticRepository.Update(animalModel));
    }

    [HttpDelete]
    [ActionName("delete")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> Delete(int id)
    { 
        return Ok(StatisticRepository.Delete(id));
    }
    
    [HttpGet]
    [ActionName("status-list")]
    [CanPermission("create-statistic")]
    public async Task<IActionResult> StatusList()
    { 
        using (var db = new AppDbContext())
        {
            var towns = db.StatisticStatus.ToList();
            return Ok(towns);
        } 
    }
}