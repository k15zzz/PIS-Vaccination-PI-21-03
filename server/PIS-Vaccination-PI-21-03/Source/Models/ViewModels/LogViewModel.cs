using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

public class LogViewModel
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string ObjId { get; set; }
    public string ObjDescr { get; set; }
    public int FkUser { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string patronymic { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string workPhone { get; set; }
    public string workEmail { get; set; }
    public string login { get; set; }
    public string OrgName { get; set; }
    public string RoleName { get; set; }




    public static implicit operator LogViewModel(LogEntitiesModel entitiesModel)
    {
        var m = new LogViewModel
        {
            Id = entitiesModel.Id,
            LogDate = entitiesModel.LogDate,
            ObjId = entitiesModel.ObjId,
            ObjDescr = entitiesModel.ObjDescr
        };

        using (var db = new AppDbContext())
        {
            m.name = db.Users.Find(entitiesModel.FkUser).Name;
            m.surname = db.Users.Find(entitiesModel.FkUser).Surname;
            m.patronymic = db.Users.Find(entitiesModel.FkUser).Patronymic;
            m.phone = db.Users.Find(entitiesModel.FkUser).Phone;
            m.email = db.Users.Find(entitiesModel.FkUser).Email;
            m.workEmail = db.Users.Find(entitiesModel.FkUser).WorkEmail;
            m.workPhone = db.Users.Find(entitiesModel.FkUser).WorkEmail;
            m.login = db.Users.Find(entitiesModel.FkUser).Login;

            m.RoleName = db.Roles.Find(db.Users.Find(entitiesModel.FkUser).FkRole).Name;
            m.OrgName = db.Organizations.Find(db.Users.Find(entitiesModel.FkUser).FkOrg).FullName;
        }
        return m;
    }
}