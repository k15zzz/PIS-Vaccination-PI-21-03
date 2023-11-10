namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class ReportViewModel
{
    public string Name { get; set; }
    public int Count { get; set; }
    public double Cost { get; set; }

    public ReportViewModel(string name, int count, double cost)
    {
        Name = name;
        Count = count;
        Cost = cost;
    }
}