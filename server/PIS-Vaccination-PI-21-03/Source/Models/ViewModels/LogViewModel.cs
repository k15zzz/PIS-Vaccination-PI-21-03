using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class LogViewModel
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string ObjId { get; set; }
    public string ObjDescr { get; set; }
    public int FkUserId { get; set; }
    public string name;
    public string surname;
    public string patronymic;
    public string phone;
    public string email;
    public string workPhone;
    public string workEmail;
    public string login;
    public int FkOrg;
    public int FkRole;
    public string orgName;
    
    
    
    public static implicit operator LogViewModel(LogEntitiesModel entitiesModel)
    {
        var m = new LogViewModel();
        m.Id = entitiesModel.Id;
        m.LogDate = entitiesModel.LogDate;
        m.ObjId = entitiesModel.ObjId;
        m.ObjDescr = entitiesModel.ObjDescr;
       // int userOrg = 0;
      //  m.FkUserId = entitiesModel.FkUserId;
        using (var db = new AppDbContext())
        {
            m.name = db.Users.Find(entitiesModel.FkUserId).Name;
            m.surname = db.Users.Find(entitiesModel.FkUserId).Surname;
            m.patronymic = db.Users.Find(entitiesModel.FkUserId).Patronymic;
            m.phone = db.Users.Find(entitiesModel.FkUserId).Phone;
            m.email = db.Users.Find(entitiesModel.FkUserId).Email;
            m.workPhone = db.Users.Find(entitiesModel.FkUserId).WorkPhone;
            m.workEmail = db.Users.Find(entitiesModel.FkUserId).workEmail;
            m.login = db.Users.Find(entitiesModel.FkUserId).Login;
         //   userOrg = db.Users.Find(entitiesModel.FkUserId).FkOrg;
            m.FkOrg = db.Users.Find(entitiesModel.FkUserId).FullName;
            
        }
        return _entetyModel;
    }
}