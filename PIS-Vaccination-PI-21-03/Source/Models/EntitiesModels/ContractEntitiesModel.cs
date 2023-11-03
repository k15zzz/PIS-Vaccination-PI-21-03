using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;

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
    [Column("fk_org_executor")]
    public OrganizationEntitiesModel Executor {get; set; }
    [Column("fk_org_client")]
    public OrganizationEntitiesModel Client {get; set; }
    [ForeignKey("FkOrganization")]
    public OrganizationEntitiesModel FkExecutor { get; set; }
    [ForeignKey("FkOrganization")]
    public OrganizationEntitiesModel FkClient { get; set; }
    
}