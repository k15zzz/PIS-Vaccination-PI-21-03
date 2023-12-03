using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

namespace PIS_Vaccination_PI_21_03.Source.Models.EntitiesModels;

[Table("logging")]
public class LogEntitiesModel
{
    [Column("id")] public int Id { get; set; }
    [Column("surname")] public string Surname { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("patronymic")] public string Patronymic { get; set; }
    [Column("phone")] public string Phone { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("organization")] public string Organization { get; set; }
    [Column("position")] public string Position { get; set; }
    [Column("work_phone")] public string WorkPhone { get; set; }
    [Column("work_email")] public string WorkEmail { get; set; }
    [Column("login")] public string Login { get; set; }
    [Column("date_time")] public DateTime LogDate { get; set; }
    [Column("object_instance_id")] public int ObjId { get; set; }
    [Column("object_description_after_action")] public string ObjDescr { get; set; }
   
    public static implicit operator LogEntitiesModel(LogViewModel viewModel)
    {
        LogEntitiesModel _entetyModel = new LogEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.Surname = viewModel.Surname;
        _entetyModel.Name = viewModel.Name;
        _entetyModel.Patronymic = viewModel.Patronymic;
        _entetyModel.Phone = viewModel.Phone;
        _entetyModel.Email = viewModel.Email;
        _entetyModel.Organization = viewModel.Organization;
        _entetyModel.Position = viewModel.Position;
        _entetyModel.WorkPhone = viewModel.WorkPhone;
        _entetyModel.WorkEmail = viewModel.WorkEmail;
        _entetyModel.Login = viewModel.Login;
        _entetyModel.LogDate = DateTime.SpecifyKind(viewModel.LogDate, DateTimeKind.Utc);
        _entetyModel.ObjId = viewModel.ObjId;
        _entetyModel.ObjDescr = viewModel.ObjDescr;
        
        return _entetyModel;
        
       
    }
}