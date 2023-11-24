using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("contract")]
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
    public int FkExecutor {get; set; }
    [Column("fk_org_client")]
    public int FkClient {get; set; }
    [ForeignKey("FkExecutor")]
    public OrganizationEntitiesModel Executor { get; set; }
    [ForeignKey("FkClient")]
    public OrganizationEntitiesModel Client { get; set; }
    
    public static implicit operator ContractEntitiesModel(ContractViewModel viewModel)
    {
        ContractEntitiesModel _entetyModel = new ContractEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.Number = viewModel.Number;
        _entetyModel.StartDate = DateTime.SpecifyKind(viewModel.StartDate, DateTimeKind.Utc);
        _entetyModel.EndDate = DateTime.SpecifyKind(viewModel.EndDate, DateTimeKind.Utc);
        _entetyModel.FkExecutor = viewModel.FkExecutor;
        _entetyModel.FkClient = viewModel.FkClient;
        return _entetyModel;
    }
}