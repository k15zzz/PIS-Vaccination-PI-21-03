using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class ContractRepository:IRepository<ContractEntitiesModel>
{
    public int CreateAsync(ContractEntitiesModel model)
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

    public void UpdateAsync(int id, JsonContent newModel)
    {
        using (var context = new AppDbContext())
        {
            var contract = context.Contracts.FindAsync(id);
            if (contract != null)
            {
                var updatedContract =
                    JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString()); 
                context.Entry(contract).CurrentValues.SetValues(updatedContract);
                context.SaveChangesAsync();
            }
        }
    }

    public Task DeleteAsync(int id)
    {
        var contract = context.Contracts.FindAsync(id);
        if (contract != null)
        {
            var contract = context.Contracts.FindAsync(id);
            if (contract != null)
            {
                context.Contracts.Remove(contract);
                context.SaveChangesAsync();
            }
            // Если не нашло, вывести сообщение об отсутствии контракта
        }
    }
}