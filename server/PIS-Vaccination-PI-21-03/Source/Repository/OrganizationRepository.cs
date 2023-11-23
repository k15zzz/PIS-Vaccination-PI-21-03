using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class OrganizationRepository
{
    public int CreateAsync(OrganizationEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Organizations.AddAsync(model);
            return db.Organizations
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<OrganizationEntitiesModel> ReadList()
    {
        List<OrganizationEntitiesModel> list;
        
        using (var context = new AppDbContext()) 
        { 
            list = context
                .Organizations
                .ToList();
        } 
        
        return list;
    }

    public async Task<OrganizationEntitiesModel> ReadItemAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.FindAsync(id).Result; // То что нужно вывести
            if (organization != null)
            {
                return organization;
            } 
            throw new NotImplementedException();
        }
    }

    public void UpdateAsync(int id, JsonContent newModel)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.FindAsync(id).Result; 
            if (organization != null)
            {
                var updatedOrganization =
                    JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString()); 
                context.Entry(organization).CurrentValues.SetValues(updatedOrganization);
                context.SaveChangesAsync();
            }
        }
    }

    public void DeleteAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.FindAsync(id).Result; // То что нужно удалить
            if (organization != null)
            {
                context.Organizations.Remove(organization);
                context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}