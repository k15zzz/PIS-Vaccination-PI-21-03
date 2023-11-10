namespace PIS_Vaccination_PI_21_03.Source.Models.DTOModels;

public class ReportRequestDTO
{
    public DateTime DateStar { get; set; }
    public DateTime DateFinish { get; set; }
    public List<int> Towns { get; set; }
}