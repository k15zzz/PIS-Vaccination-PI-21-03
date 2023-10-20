using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("сontract")]
public class ContractEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("number")]
    public string Number { get; set; }
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    [Column("end_date")]
    public DateTime EndDate { get; set; }
}