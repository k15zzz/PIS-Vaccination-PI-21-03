using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("vaccination")]
public class VaccinationEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("type")]
    public string Type { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("num_of_series")]
    public string NumOfSeries { get; set; }
    [Column("date_of_expire")]
    public DateTime DateOfExpire { get; set; }
    [Column("position_of_doc")]
    public string PositionOfDoc { get; set; }
    [Column("fk_org")]
    public int FkOrg { get; set; }
    [ForeignKey("FkOrg")]
    public OrganizationEntitiesModel Organization { get; set; }
    [Column("fk_contract")]
    public int FkContract { get; set; }
    [ForeignKey("FkContract")]
    public ContractEntitiesModel Contract { get; set; }
}