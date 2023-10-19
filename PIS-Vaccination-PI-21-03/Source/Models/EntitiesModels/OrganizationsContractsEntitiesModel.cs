namespace PIS_Vaccination_PI_21_03.Source.Models;

public class OrganizationsContractsEntitiesModels
{
    public int NumberOfOrg { get; set; }
    public int FkContract { get; set; }
    public ContractEntitiesModel Contract { get; set; }
    public int FkOrganization { get; set; }
    public OrganizationEntitiesModel Organization { get; set; }
}