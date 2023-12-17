using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Models.DTOModels;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class StatisticRepository
{
    public static List<VaccinationDTO> GetDateStatistic(DateTime dateStart, DateTime dateFinish, List<int> town)
    {

        var result = new List<VaccinationDTO>();

        List<VaccinationEntitiesModel> vactinations;
        using (var db = new AppDbContext())
        { 
            vactinations =  db.Vaccinations
                .Include(v => v.Organization)
                .Include(v => v.Organization.Town)
                .Include(v => v.Organization.Town.TownsService)
                .Where(v => dateStart <= v.Date && v.Date <= dateFinish)
                .Where(v => town.Contains(v.Organization.FkTown))
                .ToList();
        }

        foreach (var vactination in vactinations)
        {
            var idOrg = vactination.FkOrg;

            var idTown = vactination.Organization.FkTown;

            if (town.Contains(idTown))
            {
                var vacDto = new VaccinationDTO();
                vacDto.Id = vactination.Id;
                vacDto.Type = vactination.Type;
                vacDto.Date = vactination.Date;
                vacDto.NumOfSeries = vactination.NumOfSeries;
                vacDto.DateOfExpire = vactination.DateOfExpire;
                vacDto.PositionOfDoc = vactination.PositionOfDoc;
                vacDto.TownName = vactination.Organization.Town.Name;
                vacDto.Price = vactination.Organization.Town.TownsService[0].Price;
                vacDto.FKTown = vactination.Organization.Town.Id;
                result.Add(vacDto);
            }
        }

        return result;
    }

    public static List<StatisticEntitiesModel> List()
    {
        List<StatisticEntitiesModel> list;
        
        using (var context = new AppDbContext()) 
        { 
            list = context
                .Statistics
                .ToList();
        } 
        
        return list;
    }
    
    public static int Create(StatisticEntitiesModel model)
    {
        var statisticTown =  model.StatisticTown != null ? model.StatisticTown.ToArray(): null;
        using (var db = new AppDbContext())
        {
            db.Statistics.Add(model);
            db.SaveChanges();
            var id = db.Statistics
                .OrderBy(t => t.Id)
                .Last()
                .Id;

            var towns = db.StatisticTowns.Where(a => a.FkStatistic == id).ToList();
            foreach (var town in towns)
            {
                db.StatisticTowns.Remove(town);
                db.SaveChanges();
            }

            if (statisticTown != null)
            {
                foreach (var town in statisticTown)
                {
                    if (town != null)
                    {
                        town.FkStatistic = id;
                        db.StatisticTowns.Add(town);
                        db.SaveChanges();
                    }
                }
            }

            return id;
        }
    }
    
    public static StatisticEntitiesModel Read(int id)
    {
        using (var context = new AppDbContext()) 
        { 
            return context
                .Statistics
                .Find(id);
        } 
    }
    
    public static int Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var towns = context.StatisticTowns.Where(a => a.FkStatistic == id).ToList();
            foreach (var town in towns)
            {
                context.StatisticTowns.Remove(town);
                context.SaveChanges();
            }
            
            var animal = context.Statistics.Find(id);
            if (animal != null)
            {
                context.Statistics.Remove(animal);
                context.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
    
    public static StatisticEntitiesModel Update(StatisticEntitiesModel newModel) 
    {
        var statisticTown =  newModel.StatisticTown != null ? newModel.StatisticTown.ToArray(): null;
        
        using (var context = new AppDbContext())
        {
            var animal = context.Statistics.Find(newModel.Id);
            if (animal != null)
            {
                newModel.UpdateStatus = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                context.Entry(animal).CurrentValues.SetValues(newModel);
                context.SaveChanges();
                
                var towns = context.StatisticTowns.Where(a => a.FkStatistic == newModel.Id).ToList();
                foreach (var town in towns)
                {
                    context.StatisticTowns.Remove(town);
                    context.SaveChanges();
                }

                if (statisticTown != null)
                {
                    foreach (var town in statisticTown)
                    {
                        if (town != null)
                        {
                            town.FkStatistic = newModel.Id;
                            context.StatisticTowns.Add(town);
                            context.SaveChanges();
                        }
                    }
                }
            }
            else
            {
                return new StatisticEntitiesModel();
            }
            
            return context
                .Statistics
                .Find(newModel.Id);
        }
    }
}