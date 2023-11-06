using System.Text.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class AnimalRepository: IRepository<AnimalEntitiesModel>
{
    public int CreateAsync(JsonContent model)
    {
        using (var db = new AppDbContext())
        {
            var newEntity = JsonSerializer.Deserialize<AnimalEntitiesModel>(model.ToString());
            db.Animals.AddAsync(newEntity);
            return newEntity.Id;
        }
    }

    public Task<List<AnimalEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AnimalEntitiesModel> ReadItemAsync(int id)
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