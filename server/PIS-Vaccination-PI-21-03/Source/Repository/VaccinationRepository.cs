using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class VaccinationRepository
{
    public static int Create(VaccinationEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Vaccinations.Add(model);
            db.SaveChanges();
            return db.Vaccinations
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<VaccinationEntitiesModel> List()
    {
        List<VaccinationEntitiesModel> list;
        
        using (var context = new AppDbContext()) 
        { 
            list = context
                .Vaccinations
                .ToList();
        } 
        
        return list;
    }

    public static VaccinationEntitiesModel Read(int id)
    {
        using (var context = new AppDbContext()) 
        { 
            return context
                .Vaccinations
                .Find(id);
        } 
    }

    public static VaccinationEntitiesModel Update(VaccinationEntitiesModel newModel)
    {
        using (var context = new AppDbContext())
        {
            var entities = context.Vaccinations.Find(newModel.Id);
            if (entities != null)
            {
                context.Entry(entities).CurrentValues.SetValues(newModel);
                context.SaveChanges();
            }
            else
            {
                return new VaccinationEntitiesModel();
            }
            
            return context
                .Vaccinations
                .Find(newModel.Id);
        }
    }

    public static int Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Vaccinations.Find(id);
            if (animal != null)
            {
                context.Vaccinations.Remove(animal);
                context.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
}