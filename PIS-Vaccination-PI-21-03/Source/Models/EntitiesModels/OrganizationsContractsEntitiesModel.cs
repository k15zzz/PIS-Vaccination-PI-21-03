using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("organizations_contracts")]
public class OrganizationsContractsEntitiesModels
{
    [Column("id")]
    public int Id { get; set; }
    [Column("number_of_org")]
    public int NumberOfOrg { get; set; }
    [Column("fk_contract")]
    public int FkContract { get; set; }
    [ForeignKey("FkContract")]
    public ContractEntitiesModel Contract { get; set; }
    [Column("fk_organization")]
    public int FkOrganization { get; set; }
    [ForeignKey("FkOrganization")]
    public OrganizationEntitiesModel Organization { get; set; }
}