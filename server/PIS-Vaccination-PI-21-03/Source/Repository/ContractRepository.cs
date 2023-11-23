using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class ContractRepository
{
    public int CreateAsync(ContractEntitiesModel model)
    {
        // TODO: вставить чеки на джсон и соответсиве типа, ну или трай кач хотя бы
        using (var db = new AppDbContext())
        {
            db.Contracts.AddAsync(model);
            return db.Contracts
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<ContractEntitiesModel> ReadList()
    {
        List<ContractEntitiesModel> list;
        
        using (var context = new AppDbContext()) 
        { 
            list = context
                .Contracts
                .ToList();
        } 
        
        return list;
    }

    public async Task<ContractEntitiesModel> ReadItemAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var contract = context.Contracts.FindAsync(id).Result; // То что нужно вывести
            if (contract != null)
            {
                return contract;
            }
            throw new NotImplementedException();
        }
    }

    public void UpdateAsync(int id, JsonContent newModel)
    {
        using (var context = new AppDbContext())
        {
            var contract = context.Contracts.FindAsync(id).Result;
            if (contract != null)
            {
                var updatedContract =
                    JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString()); 
                context.Entry(contract).CurrentValues.SetValues(updatedContract);
                context.SaveChangesAsync();
            }
        }
    }

    public void DeleteAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var contract = context.Contracts.FindAsync(id).Result; // То что нужно удалить
            if (contract != null)
            {
                context.Contracts.Remove(contract);
                context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}