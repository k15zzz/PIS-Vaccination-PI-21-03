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
    [Column("fk_animal")]
    public int FkAnimal { get; set; }
    [ForeignKey("FkAnimal")]
    public ContractEntitiesModel Animal { get; set; }
    
    public static implicit operator VaccinationEntitiesModel(VaccinationViewModel viewModel)
    {
        var _entetyModel = new VaccinationEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.Type = viewModel.Type;
        _entetyModel.Date = DateTime.SpecifyKind(viewModel.Date, DateTimeKind.Utc);
        _entetyModel.NumOfSeries = viewModel.NumOfSeries;;
        _entetyModel.DateOfExpire = DateTime.SpecifyKind(viewModel.DateOfExpire, DateTimeKind.Utc);
        _entetyModel.PositionOfDoc = viewModel.PositionOfDoc;
        _entetyModel.FkOrg = viewModel.FkOrg;
        _entetyModel.FkContract = viewModel.FkContract;
        _entetyModel.FkAnimal = viewModel.FkAnimal;
        return _entetyModel;
    }
}