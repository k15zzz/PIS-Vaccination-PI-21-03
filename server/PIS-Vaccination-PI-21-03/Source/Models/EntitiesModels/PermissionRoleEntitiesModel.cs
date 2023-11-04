using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("permission_role")]
public class PermissionRoleEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("fk_role")]
    public int FkRole { get; set; }
    [ForeignKey("FkRole")]
    public RoleEntitiesModel Role { get; set; }
    [Column("fk_permission")]
    public int FkPermission { get; set; }
    [ForeignKey("FkPermission")]
    public PermissionEntitiesModel Permission { get; set; }
}