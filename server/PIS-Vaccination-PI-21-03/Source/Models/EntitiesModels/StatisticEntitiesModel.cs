using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("statistics")]
public class StatisticEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("date_start")]
    public DateTime DateStart { get; set; }
    [Column("date_finish")]
    public DateTime DateFinish { get; set; }
    [Column("update_status")]
    public DateTime UpdateStatus { get; set; }
    [Column("fk_status")]
    public int FkStatus { get; set; }
    [ForeignKey("FkStatus")]
    public AnimalStatusEntitiesModel Status { get; set; }
    public List<StatisticTownEntitiesModel> StatisticTown { get; set; }
    
    public static implicit operator StatisticEntitiesModel(StatisticViewModel viewModel)
    {
        StatisticEntitiesModel _entetyModel = new StatisticEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.DateStart = DateTime.SpecifyKind(viewModel.DateStart, DateTimeKind.Utc);
        _entetyModel.DateFinish = DateTime.SpecifyKind(viewModel.DateFinish, DateTimeKind.Utc);
        _entetyModel.UpdateStatus = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        _entetyModel.FkStatus = viewModel.FkStatus;
        if (viewModel.StatisticTown != null)
        {
            foreach (var statisticTown in viewModel.StatisticTown)
            {
                if (_entetyModel.StatisticTown == null)
                {
                    _entetyModel.StatisticTown = new List<StatisticTownEntitiesModel>();
                }
                _entetyModel.StatisticTown.Add(statisticTown);
            }
        }
        return _entetyModel;
    }
}