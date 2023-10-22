using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Services;

public class PermissionService
{ 
    public static List<string> PermissionScopedList (int userId)
    {
        List<string> scoped;
        
        using (AppDbContext db = new AppDbContext())
        { 
            scoped = db
                .Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Role.PermissionRoles)
                .Select(pr => pr.Permission.Name)
                .ToList();
        }

        return scoped;
    } 
}