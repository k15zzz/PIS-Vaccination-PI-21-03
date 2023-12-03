using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Models.DTOModels;
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
}