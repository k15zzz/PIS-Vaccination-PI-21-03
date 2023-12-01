using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("logging")]
public class LogEntitiesModel
{
    [Column("id")] public int Id { get; set; }
    [Column("date_time")] public DateTime LogDate { get; set; }
    [Column("object_instance_id")] public string ObjId { get; set; }
    [Column("object_description_after_action")] public string ObjDescr { get; set; }
    [Column("fk_user")] public int FkUser { get; set; }
    [ForeignKey("FkUser")] public UserEntitiesModels User { get; set; }
    public static implicit operator LogEntitiesModel(LogViewModel viewModel)
    {
        LogEntitiesModel _entetyModel = new LogEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.LogDate = DateTime.SpecifyKind(viewModel.LogDate, DateTimeKind.Utc);
        _entetyModel.ObjId = viewModel.ObjId;
        _entetyModel.ObjDescr = viewModel.ObjDescr;
        _entetyModel.FkUserId = viewModel.FkUserId;
        return _entetyModel;
    }
}