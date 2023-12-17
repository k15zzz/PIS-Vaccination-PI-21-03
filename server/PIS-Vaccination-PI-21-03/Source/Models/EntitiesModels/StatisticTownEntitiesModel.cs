using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("statistic_town")]
public class StatisticTownEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("count")]
    public double Count { get; set; }
    [Column("cost")]
    public double Cost { get; set; }
    [Column("fk_town")]
    public int FkTown { get; set; }
    [ForeignKey("FkTown")]
    public TownEntitiesModel Town { get; set; }
    [Column("fk_statistic")]
    public int FkStatistic { get; set; }
    [ForeignKey("FkStatistic")]
    public StatisticEntitiesModel Statistic { get; set; }
    
    public static implicit operator StatisticTownEntitiesModel(StatisticTownViewModel viewModel)
    {
        StatisticTownEntitiesModel _entetyModel = new StatisticTownEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.Count = viewModel.Count;
        _entetyModel.Cost = viewModel.Cost;
        _entetyModel.FkTown = viewModel.FkTown;
        _entetyModel.FkStatistic = viewModel.FkStatistic;
        return _entetyModel;
    }
}