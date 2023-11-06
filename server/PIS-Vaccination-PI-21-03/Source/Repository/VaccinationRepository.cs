using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class VaccinationRepository : IRepository<VaccinationEntitiesModel>
{
    public int CreateAsync(JsonContent model)
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

    public Task UpdateAsync(int bookId, JsonContent UpdatedModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}