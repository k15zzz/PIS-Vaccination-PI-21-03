using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class VaccinationRepository
{
    public static int CreateAsync(VaccinationEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Vaccinations.AddAsync(model);
            return db.Vaccinations
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<VaccinationEntitiesModel> List()
    {
        throw new NotImplementedException();
    }

    public static VaccinationEntitiesModel Read(int id)
    {
        throw new NotImplementedException();
    }

    public static void Update(int id, JsonContent newModel)
    {
        using (var context = new AppDbContext())
        {
            var vaccination = context.Vaccinations.FindAsync(id);
            if (vaccination != null)
            {
                var updatedVaccination =
                    JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString());
                context.Entry(vaccination).CurrentValues.SetValues(updatedVaccination);
                context.SaveChangesAsync();
            }
        }
    }

    public static void Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var vaccination = context.Vaccinations.FindAsync(id).Result;
            if (vaccination != null)
            {
                context.Vaccinations.Remove(vaccination);
                context.SaveChangesAsync();
            }
        }
    }
}