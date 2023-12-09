using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("users")]
public class UserEntitiesModels
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("surname")]
    public string Surname { get; set; }
    [Column("patronymic")]
    public string Patronymic { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("phone")]
    public string Phone { get; set; }
    [Column("work_email")]
    public string WorkEmail { get; set; }
    [Column("work_phone")]
    public string WorkPhone { get; set; }
    
    [Column("login")]
    public string Login { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("fk_org")]
    public int FkOrg { get; set; }
    [ForeignKey("FkOrg")]
    public OrganizationEntitiesModel Organization { get; set; }
    [Column("fk_role")]
    public int FkRole { get; set; }
    [ForeignKey("FkRole")]
    public RoleEntitiesModel Role { get; set; }
}
