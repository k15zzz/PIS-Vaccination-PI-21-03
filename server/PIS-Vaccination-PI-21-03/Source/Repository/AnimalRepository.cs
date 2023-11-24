using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class AnimalRepository
{
    public static int Create(AnimalEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Animals.Add(model);
            db.SaveChanges();
            return db.Animals
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<AnimalEntitiesModel> List()
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

    public static AnimalEntitiesModel Read(int id)
    {
        using (var context = new AppDbContext()) 
        { 
            return context
                .Animals
                .Find(id);
        } 
    }

    public static AnimalEntitiesModel Update(AnimalEntitiesModel newModel) 
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Animals.Find(newModel.Id);
            if (animal != null)
            {
                context.Entry(animal).CurrentValues.SetValues(newModel);
                context.SaveChanges();
            }
            else
            {
                return new AnimalEntitiesModel();
            }
            
            return context
                .Animals
                .Find(newModel.Id);
        }
    }

    public static int Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var animal = context.Animals.Find(id);
            if (animal != null)
            {
                context.Animals.Remove(animal);
                context.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
}