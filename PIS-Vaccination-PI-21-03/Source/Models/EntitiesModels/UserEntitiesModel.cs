namespace PIS_Vaccination_PI_21_03.Source.Models;

public class UserEntitiesModels
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int FkOrg { get; set; }
    public OrganizationEntitiesModel Organization { get; set; }
    public int FkRole { get; set; }
    public RoleEntitiesModel Role { get; set; }
}