using System.Text;
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
    [HttpDelete]
    [ActionName("delete")]
    public async Task<IActionResult> Delete(int id) =>
        Ok(LogRepository.Delete(id));
    
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List() =>
        Ok(LogRepository.List().Select(x => (LogViewModel)x).ToList());

    [HttpPost]
    [ActionName("export")]
    public FileResult ExportToExcel(int id)
    {
        string log = LogRepository.Read(id).ToString();
        return File(Encoding.ASCII.GetBytes(log), "application/vnd.ms-excel","export.xls");
    }
}
//todo поправить