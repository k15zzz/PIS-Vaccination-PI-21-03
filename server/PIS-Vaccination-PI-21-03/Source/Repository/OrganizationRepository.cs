using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class OrganizationRepository : IRepository<OrganizationEntitiesModel>
{
    public int CreateAsync(JsonContent model)
    {
        using (var db = new AppDbContext())
        {
            var newEntity = JsonSerializer.Deserialize<OrganizationEntitiesModel>(model.ToString());
            db.Organizations.AddAsync(newEntity);
            return newEntity.Id;
        }
    }

    public Task<List<OrganizationEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationEntitiesModel> ReadItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int bookId, JsonContent UpdatadModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}