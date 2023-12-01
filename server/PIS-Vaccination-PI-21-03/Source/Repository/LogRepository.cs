using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class LogRepository
{
    public static int Create(LogEntitiesModel model)
    {
        using (var db = new AppDbContext())
        {
            db.Loggings.Add(model);
            db.SaveChanges();
            return db.Loggings
                .OrderBy(t => t.Id)
                .Last()
                .Id;
        }
    }

    public static List<LogEntitiesModel> List()
    { 
        List<LogEntitiesModel> list;
        
        using (var context = new AppDbContext()) 
        { 
            list = context
                .Loggings
                .ToList();
        } 
        
        return list;
    }

    public static LogEntitiesModel Read(int id)
    {
        using (var context = new AppDbContext()) 
        { 
            return context
                .Loggings
                .Find(id);
        } 
    }

    public static LogEntitiesModel Update(LogEntitiesModel newModel) 
    {
        using (var context = new AppDbContext())
        {
            var log = context.Loggings.Find(newModel.Id);
            if (log != null)
            {
                context.Entry(log).CurrentValues.SetValues(newModel);
                context.SaveChanges();
            }
            else
            {
                return new LogEntitiesModel();
            }
            
            return context
                .Loggings
                .Find(newModel.Id);
        }
    }

    public static int Delete(int id)
    {
        using (var context = new AppDbContext())
        {
            var log = context.Loggings.Find(id);
            if (log != null)
            {
                context.Loggings.Remove(log);
                context.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
}