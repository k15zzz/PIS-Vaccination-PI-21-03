using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("status_statistic")]
public class StatusStatisticModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
}