using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("towns_service")]
public class TownsServiceEntitiesModels
{
    [Column("id")]
    public int Id { get; set; }
    [Column("fk_town")]
    public int FkTown { get; set; }
    [ForeignKey("FkTown")]
    public TownEntitiesModel Town { get; set; }
    [Column("fk_service")]
    public int FkService { get; set; }
    [ForeignKey("FkService")]
    public int Price { get; set; }
}