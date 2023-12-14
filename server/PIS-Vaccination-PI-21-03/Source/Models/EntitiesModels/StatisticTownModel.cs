using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("statistic_town")]
public class StatisticTownModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("count")]
    public string Count { get; set; }
    [Column("cost")]
    public string Cost { get; set; }
    [Column("fk_town")]
    public int FkTown { get; set; }
    [ForeignKey("FkTown")]
    public TownEntitiesModel Town { get; set; }
    [Column("fk_statistic")]
    public int FkStatistic { get; set; }
    [ForeignKey("FkStatistic")]
    public AnimalCategoryEntitiesModel Statistic { get; set; }
}