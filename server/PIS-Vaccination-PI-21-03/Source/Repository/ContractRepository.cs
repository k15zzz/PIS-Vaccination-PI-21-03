using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class ContractRepository
{
    public static int Create(ContractEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Contracts.Add(model);
            db.SaveChanges(); 
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

    public static ContractEntitiesModel Read(int id)
    {
        using (var context = new AppDbContext()) 
        { 
            return context
                .Contracts
                .Find(id);
        } 
    }

    public static ContractEntitiesModel Update(ContractEntitiesModel newModel)
    {
        using (var context = new AppDbContext())
        {
            var contract = context.Contracts.Find(newModel.Id);
            if (contract != null)
            {
                context.Entry(contract).CurrentValues.SetValues(newModel);
                context.SaveChanges();
                return context
                    .Contracts
                    .Find(newModel.Id);
            }
            else
            {
                return new ContractEntitiesModel();
            }
        }
    }

    public static int Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var contract = context.Contracts.Find(id);
            if (contract != null)
            {
                context.Contracts.Remove(contract);
                context.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
}