using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class StatisticViewModel
{
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateFinish { get; set; }
    public DateTime? UpdateStatus { get; set; }
    public int FkStatus { get; set; }
    public string? Status { get; set; }
    public List<StatisticTownViewModel>? StatisticTown { get; set; }
    
    public static implicit operator StatisticViewModel(StatisticEntitiesModel entitiesModel)
    {
        var m = new StatisticViewModel();
        m.Id = entitiesModel.Id;
        m.DateStart = entitiesModel.DateStart;
        m.DateFinish = entitiesModel.DateFinish;
        m.UpdateStatus = entitiesModel.UpdateStatus;
        m.FkStatus = entitiesModel.FkStatus;
        using (var db = new AppDbContext())
        {
            m.Status = db.StatisticStatus.Find(entitiesModel.FkStatus).Name;
            m.StatisticTown = new List<StatisticTownViewModel>();
            var towns  = db.StatisticTowns.Where(a => a.FkStatistic == entitiesModel.Id).ToList();
            foreach (var town in towns)
            {
                m.StatisticTown.Add(town);
            }
        }
        return m;
    }
}