using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class AnimalRepository
{
    public static async Task<int> Create(AnimalEntitiesModel? model)
    {
        await using var db = new AppDbContext();
        await db.Animals.AddAsync(model);
        await db.SaveChangesAsync();
        return (await Task.Run(() => db.Animals.OrderBy(t => t.Id).Last().Id));
    }

    public static async Task<List<AnimalEntitiesModel?>> List()
        => await Task.Run(()=>new AppDbContext().Animals.ToList());

    public static async Task<AnimalEntitiesModel?> Read(int id) =>
        await Task.Run(() => new AppDbContext().Animals.Find(id));
    public static async Task<AnimalEntitiesModel?> Update(AnimalEntitiesModel newModel)
    {
        await using var context = new AppDbContext();

        var animal = await context.Animals.FindAsync(newModel.Id);
        if (animal != null)
        {
            await Task.Run(() => context.Entry(animal).CurrentValues.SetValues(newModel));
            await context.SaveChangesAsync();
        }
        else
        {
            return new AnimalEntitiesModel();
        }
            
        return (await context
            .Animals
            .FindAsync(newModel.Id));
    }

    public static async Task<int> Delete(int id)
    {
        await using var context = new AppDbContext();
        
        var animal = await context.Animals.FindAsync(id);
        if (animal == null)
            return 0;
        
        context.Animals.Remove(animal);
        await context.SaveChangesAsync();
        return 1;
    }
}