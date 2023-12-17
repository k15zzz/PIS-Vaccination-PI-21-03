using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class StatisticTownViewModel
{
    public int Id { get; set; }
    public double Count { get; set; }
    public double Cost { get; set; }
    public int FkTown { get; set; }
    public int FkStatistic { get; set; }
    public string? Town { get; set; }
    
    public static implicit operator StatisticTownViewModel(StatisticTownEntitiesModel entitiesModel)
    {
        var m = new StatisticTownViewModel();
        m.Id = entitiesModel.Id;
        m.Count = entitiesModel.Count;
        m.Cost = entitiesModel.Cost;
        m.FkTown = entitiesModel.FkTown;
        m.FkStatistic = entitiesModel.FkStatistic;
        using (var db = new AppDbContext())
        {
            m.Town = db.Towns.Find(entitiesModel.FkTown).Name;
        }
        return m;
    }
}