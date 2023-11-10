using System.ComponentModel.DataAnnotations.Schema;

namespace PIS_Vaccination_PI_21_03.Source.Models;

public class ContractViewModel
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int FkExecutor { get; set; }
    public int FkClient { get; set; }
    
}