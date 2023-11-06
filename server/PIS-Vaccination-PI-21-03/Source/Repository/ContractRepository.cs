using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class ContractRepository:IRepository<ContractEntitiesModel>
{
    public int CreateAsync(JsonContent model)
    {
        // TODO: вставить чеки на джсон и соответсиве типа, ну или трай кач хотя бы
        using (var db = new AppDbContext())
        {
            var newEntity = JsonSerializer.Deserialize<ContractEntitiesModel>(model.ToString());
            db.Contracts.AddAsync(newEntity);
            return newEntity.Id;
        }
    }

    public Task<List<ContractEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ContractEntitiesModel> ReadItemAsync(int id)
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