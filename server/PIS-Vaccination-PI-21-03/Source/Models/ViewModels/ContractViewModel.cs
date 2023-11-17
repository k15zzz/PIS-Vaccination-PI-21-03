using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

public class ContractViewModel
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int FkExecutor { get; set; }
    public int FkClient { get; set; }
    public string? Executor { get; set; }
    public string? Client { get; set; }
    
    
    public static implicit operator ContractViewModel(ContractEntitiesModel entities)
    {
        ContractViewModel m = new ContractViewModel();
        m.Id = entities.Id;
        m.Number = entities.Number;
        m.StartDate = entities.StartDate;
        m.EndDate = entities.EndDate;
        m.FkExecutor = entities.FkExecutor;
        m.FkClient = entities.FkClient;
        using (var db = new AppDbContext())
        {
            m.Executor = db.Organizations.Find(entities.FkExecutor).FullName;
            m.Client = db.Organizations.Find(entities.FkClient).FullName;
        }
        return m;
    }
}