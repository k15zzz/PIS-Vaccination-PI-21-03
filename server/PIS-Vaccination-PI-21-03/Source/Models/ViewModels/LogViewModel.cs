using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class LogViewModel
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string ObjId { get; set; }
    public string ObjDescr { get; set; }
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
    public int FkUser { get; set; }

    public static implicit operator LogViewModel(EntitiesModels.LogEntitiesModel entitiesModel)
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
            var _user = db.Users.Find(entitiesModel.FkUser);
            m.name = _user.Name;
            m.surname = _user.Surname;
            m.patronymic = _user.Patronymic;
            m.phone = _user.Phone;
            m.email = _user.Email;
            m.workEmail = _user.WorkEmail;
            m.workPhone = _user.WorkEmail;
            m.login = _user.Login;
            m.RoleName = db.Roles.Find(_user.FkRole).Name;
            m.OrgName = db.Organizations.Find(_user.FkOrg).FullName;
        }
        return m;
    }
}