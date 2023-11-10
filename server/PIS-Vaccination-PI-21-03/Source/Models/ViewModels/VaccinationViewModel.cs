
namespace PIS_Vaccination_PI_21_03.Source.Models;

public class VaccinationViewModel
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string NumOfSeries { get; set; }
    public DateTime DateOfExpire { get; set; }
    public string PositionOfDoc { get; set; }
    public int FkOrg { get; set; }
    public int FkContract { get; set; }
}