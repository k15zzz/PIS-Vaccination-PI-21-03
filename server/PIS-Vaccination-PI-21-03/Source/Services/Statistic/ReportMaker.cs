using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

namespace PIS_Vaccination_PI_21_03.Source.Services.Statistic;

public class ReportMaker
{
    private List<Town> townList = new List<Town>();
    
    public class Town
    {
        public int FkTown { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        
        public Town(string name, int count, double cost, int fkTown)
        {
            FkTown = fkTown;
            Name = name;
            Count = count;
            Cost = cost;
        }
    }

    public ReportMaker AddTown(string name, int count, double cost, int fkTown)
    {
        townList.Add(new Town(name, count, cost, fkTown));
        return this;
    }

    public List<ReportViewModel> ListReportViewModels()
    {
        var reportViewModels = new List<ReportViewModel>();

        foreach (var town in townList)
        {
            reportViewModels.Add(new ReportViewModel(town.Name, town.Count, town.Cost, town.FkTown));
        }

        return reportViewModels;
    }

    public Town[] GetTown()
    {
        return townList.ToArray();
    }
}