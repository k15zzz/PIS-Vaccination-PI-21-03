using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Repository;

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
    
    public static implicit operator VaccinationEntitiesModel(VaccinationViewModel viewNodel)
    {
        VaccinationEntitiesModel _entetyModel = new VaccinationEntitiesModel();
        _entetyModel.Id = viewNodel.Id;
        _entetyModel.Type = viewNodel.Type;
        _entetyModel.Date = viewNodel.Date;
        _entetyModel.PositionOfDoc = viewNodel.PositionOfDoc;
        _entetyModel.NumOfSeries = viewNodel.NumOfSeries;
        _entetyModel.DateOfExpire = viewNodel.DateOfExpire;
        _entetyModel.FkOrg = viewNodel.FkOrg;
        _entetyModel.FkContract = viewNodel.FkContract;
        using (var db = new AppDbContext())
        {
            _entetyModel.Organization = db.Organizations.Find(viewNodel.FkOrg);
            _entetyModel.Contract = db.Contracts.Find(viewNodel.FkContract);
        }
        return _entetyModel;
    }
}