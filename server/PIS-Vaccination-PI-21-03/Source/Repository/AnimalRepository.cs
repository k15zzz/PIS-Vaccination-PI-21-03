using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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

    public void UpdateAsync(int id, JsonContent newModel) 
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Animals.FindAsync(id); //то, что нужно обновить
            if (animal != null)
            {
                var updatedAnimal = JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString()); //то, чем обновляем
                context.Entry(animal).CurrentValues.SetValues(updatedAnimal);
                context.SaveChangesAsync();
            }
            //сделать что-то, еасли не найдено
        }
    }

    public Task DeleteAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}