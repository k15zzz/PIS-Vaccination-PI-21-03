using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class VaccinationRepository : IRepository<VaccinationEntitiesModel>
{
    public int CreateAsync(VaccinationEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            var newEntity = JsonSerializer.Deserialize<VaccinationEntitiesModel>(model.ToString());
            db.Vaccinations.AddAsync(newEntity);
            return newEntity.Id;
        }
    }

    public Task<List<VaccinationEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<VaccinationEntitiesModel> ReadItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(int id, JsonContent newModel)
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

    public Task DeleteAsync(int bookId)
    {
        using (var context = new AppDbContext())
        {
            var vaccination = context.Vaccinations.FindAsync(id);
            if (vaccination != null)
            {
                context.Vaccinations.Remove(vaccination);
                context.SaveChangesAsync();
            }
            // Если не нашло, вывести сообщение об отсутствии вакцинации
        }
    }
}