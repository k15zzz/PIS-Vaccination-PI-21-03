using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

public class LogViewModel
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string ObjId { get; set; }
    public string ObjDescr { get; set; }
    public int FkUser { get; set; }
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
            m.name = db.Users.Find(entitiesModel.FkUser).Name;
            m.surname = db.Users.Find(entitiesModel.FkUser).Surname;
            m.patronymic = db.Users.Find(entitiesModel.FkUser).Patronymic;
            m.phone = db.Users.Find(entitiesModel.FkUser).Phone;
            m.email = db.Users.Find(entitiesModel.FkUser).Email;
            m.workPhone = db.Users.Find(entitiesModel.FkUser).WorkPhone;
            m.workEmail = db.Users.Find(entitiesModel.FkUser).WorkEmail;
            m.login = db.Users.Find(entitiesModel.FkUser).Login;
         //   userOrg = db.Users.Find(entitiesModel.FkUserId).FkOrg;
            m.FkOrg = db.Users.Find(entitiesModel.FkUserId).FullName;
            
        }
        return m;
    }
}