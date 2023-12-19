using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("role_status_statistic")]
public class RoleStatusStatisticEntitiesMode
{
    [Column("id")]
    public int Id { get; set; }
    [Column("fk_role")]
    public int FkRole { get; set; }
    [ForeignKey("FkRole")]
    public RoleEntitiesModel Role { get; set; }
    [Column("fk_status_statistic")]
    public int FkStatusStatistic { get; set; }
    [ForeignKey("FkStatusStatistic")]
    public StatusStatisticEntitiesModel StatusStatistic { get; set; }
}