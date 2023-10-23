using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Services.Permission;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]")]
public class PermissionController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPermissionList(int userId)
    {
        return Ok(PermissionService.PermissionScopedList(userId));
    }
}