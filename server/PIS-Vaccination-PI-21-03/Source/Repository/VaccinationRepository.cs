using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class VaccinationRepository : IRepository<VaccinationEntitiesModel>
{
    public int CreateAsync(VaccinationEntitiesModel model)
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

    public Task<List<VaccinationEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<VaccinationEntitiesModel> ReadItemAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var vaccination = context.Vaccinations.FindAsync(id).Result; // То что нужно вывести
            if (vaccination != null)
            {
                return vaccination;
            }
            throw new NotImplementedException();
        }
    }

    public void UpdateAsync(int id, JsonContent newModel)
    {
        using (var context = new AppDbContext())
        {
            var vaccination = context.Vaccinations.FindAsync(id).Result;
            if (vaccination != null)
            {
                var updatedVaccination =
                    JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString());
                context.Entry(vaccination).CurrentValues.SetValues(updatedVaccination);
                context.SaveChangesAsync();
            }
        }
    }

    public void DeleteAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var vaccination = context.Vaccinations.FindAsync(id).Result; // То что нужно удалить
            if (vaccination != null)
            {
                context.Vaccinations.Remove(vaccination);
                context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}