using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Repository;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;
using PIS_Vaccination_PI_21_03.Source.Models.EntitiesModels;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class LogReaderController : ControllerBase
{
    [HttpGet]
    [ActionName("read")]
    public async Task<IActionResult> Read(int id) =>
        Ok((LogViewModel)LogRepository.Read(id));

    [HttpPost]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] LogViewModel newLog) =>
        Ok(LogRepository.Create(newLog));
    
    [HttpPut] 
    [ActionName("update")]
    public async Task<IActionResult> Update([FromBody] LogViewModel logModel) => 
        Ok((LogViewModel)LogRepository.Update(logModel));

    [HttpDelete]
    [ActionName("delete")]
    public async Task<IActionResult> Delete(int id) =>
        Ok(LogRepository.Delete(id));
    
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List() =>
        Ok(LogRepository.List().Select(x => (LogViewModel)x).ToList());
}