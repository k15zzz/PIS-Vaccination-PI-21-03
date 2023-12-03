using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class LogViewModel
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public int ObjId { get; set; }
    public string ObjDescr { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string WorkPhone { get; set; }
    public string WorkEmail { get; set; }
    public string Login { get; set; }
    public string Organization { get; set; }
    public string Position { get; set; }
    

    public static implicit operator LogViewModel(EntitiesModels.LogEntitiesModel entetyModel)
    {
        var m = new LogViewModel
        {
            Id = entetyModel.Id,
            Surname = entetyModel.Surname,
            Name = entetyModel.Name,
            Patronymic = entetyModel.Patronymic,
            Phone = entetyModel.Phone,
            Email = entetyModel.Email,
            Organization = entetyModel.Organization,
            Position = entetyModel.Position,
            WorkPhone = entetyModel.WorkPhone,
            WorkEmail = entetyModel.WorkEmail,
            Login = entetyModel.Login,
            LogDate = DateTime.SpecifyKind(entetyModel.LogDate, DateTimeKind.Utc),
            ObjId = entetyModel.ObjId,
            ObjDescr = entetyModel.ObjDescr
        };
        
        return m;
    }
}