
using PIS_Vaccination_PI_21_03.Source.Repository;

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
    public int FkAnimal { get; set; }
    public string? Org { get; set; }
    public string? Contract { get; set; }
    public string? Animal { get; set; }
    
    public static implicit operator VaccinationViewModel(VaccinationEntitiesModel entitiesModel)
    {
        var m = new VaccinationViewModel();
        m.Id = entitiesModel.Id;
        m.Type = entitiesModel.Type;
        m.Date = entitiesModel.Date;
        m.NumOfSeries = entitiesModel.NumOfSeries;
        m.DateOfExpire = entitiesModel.DateOfExpire;
        m.PositionOfDoc = entitiesModel.PositionOfDoc;
        m.FkOrg = entitiesModel.FkOrg;
        m.FkContract = entitiesModel.FkContract;
        m.FkAnimal = entitiesModel.FkAnimal;
        using (var db = new AppDbContext())
        {
            m.Org = db.Organizations.Find(entitiesModel.FkOrg).FullName;
            m.Contract = db.Contracts.Find(entitiesModel.FkContract).Number;
            m.Animal = db.Animals.Find(entitiesModel.FkOrg).Name;
        }
        return m;
    }
}