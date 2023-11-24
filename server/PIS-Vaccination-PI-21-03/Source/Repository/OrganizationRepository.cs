using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class OrganizationRepository
{
    public static int Create(OrganizationEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Organizations.Add(model);
            db.SaveChanges();
            return db.Organizations
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<OrganizationEntitiesModel> List()
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

    public static OrganizationEntitiesModel Read(int id)
    {
        using (var context = new AppDbContext()) 
        { 
            return context
                .Organizations
                .Find(id);
        } 
    }

    public static OrganizationEntitiesModel Update(OrganizationEntitiesModel newModel)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.Find(newModel.Id); 
            if (organization != null)
            {
                context.Entry(organization).CurrentValues.SetValues(newModel);
                context.SaveChanges();
            }
            else
            {
                return new OrganizationEntitiesModel();
            }
            
            return context.Organizations.Find(newModel.Id);
        }
    }

    public static int Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var organization = context.Organizations.Find(id);
            if (organization != null)
            {
                context.Organizations.Remove(organization);
                context.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
}