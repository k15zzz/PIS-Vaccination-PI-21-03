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
    
    public static implicit operator ContractEntitiesModel(ContractViewModel viewNodel)
    {
        ContractEntitiesModel _entetyModel = new ContractEntitiesModel();
        _entetyModel.Id = viewNodel.Id;
        _entetyModel.Number = viewNodel.Number;
        _entetyModel.StartDate = viewNodel.StartDate;
        _entetyModel.EndDate = viewNodel.EndDate;
        _entetyModel.FkExecutor = viewNodel.FkExecutor;
        _entetyModel.FkClient = viewNodel.FkClient;
        using (var db = new AppDbContext())
        {
            _entetyModel.Executor = db.Organizations.Find(viewNodel.FkExecutor);
            _entetyModel.Client = db.Organizations.Find(viewNodel.FkClient);
        }
        return _entetyModel;
    }
}