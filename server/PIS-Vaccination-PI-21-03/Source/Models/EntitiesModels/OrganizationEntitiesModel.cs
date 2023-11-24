using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Repository;
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
    public TownEntitiesModel? Town { get; set; }
    
    public static implicit operator OrganizationEntitiesModel(OrganizationViewModel viewNodel)
    {
        OrganizationEntitiesModel _entetyModel = new OrganizationEntitiesModel();
        _entetyModel.Id = viewNodel.Id;
        _entetyModel.FullName = viewNodel.FullName;
        _entetyModel.Inn = viewNodel.Inn;
        _entetyModel.Kpp = viewNodel.Kpp;
        _entetyModel.Address = viewNodel.Address;
        _entetyModel.Type = viewNodel.Type;
        _entetyModel.LegalEntity = viewNodel.LegalEntity;
        _entetyModel.FkTown = viewNodel.FkTown;
        return _entetyModel;
    }
}