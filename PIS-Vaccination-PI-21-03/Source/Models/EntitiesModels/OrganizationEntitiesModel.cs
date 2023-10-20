using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("organization")]
public class OrganizationEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("full_name")]
    public string FullName { get; set; }
    [Column("inn")]
    public string Inn { get; set; }
    [Column("kpp")]
    public string Kpp { get; set; }
    [Column("address")]
    public string Address { get; set; }
    [Column("type")]
    public string Type { get; set; }
    [Column("legal_entity")]
    public bool LegalEntity { get; set; }
    [Column("fk_town")]
    public int FkTown { get; set; }
    [ForeignKey("FkTown")]
    public TownEntitiesModel Town { get; set; }
}