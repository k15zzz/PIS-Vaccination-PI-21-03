using System.Text;
using PIS_Vaccination_PI_21_03.Source.Models.EntitiesModels;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public static class LogRepository
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

    public static string GenerateCSV(int id)
    {
        var builder = new StringBuilder();
        foreach (var attribute in typeof(LogEntitiesModel)
                     .GetProperties()
                     .Select(property => property.Name)
                     .ToArray())
        {
            builder.Append(attribute.ToString());
            builder.Append(",");
        }

        builder.Append("\n");

        builder.Append(Read(id).Id.ToString());
        builder.Append(", " + Read(id).Surname.ToString());
        builder.Append(", " + Read(id).Name.ToString());
        builder.Append(", " + Read(id).Patronymic.ToString());
        builder.Append(", " + Read(id).Phone.ToString());
        builder.Append(", " + Read(id).Email.ToString());
        builder.Append(", " + Read(id).Organization.ToString());
        builder.Append(", " + Read(id).Position.ToString());
        builder.Append(", " + Read(id).WorkPhone.ToString());
        builder.Append(", " + Read(id).WorkEmail.ToString());
        builder.Append(", " + Read(id).Login.ToString());
        builder.Append(", " + Read(id).LogDate.ToString());
        builder.Append(", " + Read(id).ObjId.ToString());
        builder.Append(", " + Read(id).ObjDescr.ToString());

        return builder.ToString();

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