using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class AnimalRepository
{
    public int CreateAsync(AnimalEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Animals.AddAsync(model);
            return db.Animals
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<AnimalEntitiesModel> ReadList()
    { 
        List<AnimalEntitiesModel> list;
        
        using (var context = new AppDbContext()) 
        { 
            list = context
                .Animals
                .ToList();
        } 
        
        return list;
    }

    public async Task<AnimalEntitiesModel> ReadItemAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Animals.FindAsync(id).Result; // То что нужно вывести
            if (animal != null)
            {
                return animal;
            }
            throw new NotImplementedException();
        }
    }

    public void UpdateAsync(int id, JsonContent newModel) 
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Animals.FindAsync(id).Result; //то, что нужно обновить
            if (animal != null)
            {
                var updatedAnimal = JsonSerializer.Deserialize<AnimalEntitiesModel>(newModel.ToString()); //то, чем обновляем
                context.Entry(animal).CurrentValues.SetValues(updatedAnimal);
                context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    public void DeleteAsync(int id)
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Animals.FindAsync(id).Result; // То что нужно удалить
            if (animal != null)
            {
                context.Animals.Remove(animal);
                context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}