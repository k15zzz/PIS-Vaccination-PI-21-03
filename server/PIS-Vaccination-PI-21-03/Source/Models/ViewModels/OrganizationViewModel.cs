using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

public class OrganizationViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Inn { get; set; }
    public string Kpp { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
    public bool LegalEntity { get; set; }
    public int FkTown { get; set; }
    public string Town { get; set; }
    
    public static implicit operator OrganizationViewModel(OrganizationEntitiesModel entitiesModel)
    {
        var m = new OrganizationViewModel();
        m.Id = entitiesModel.Id;
        m.FullName = entitiesModel.FullName;
        m.Inn = entitiesModel.Inn;
        m.Kpp = entitiesModel.Kpp;
        m.Address = entitiesModel.Address;
        m.Type = entitiesModel.Type;
        m.LegalEntity = entitiesModel.LegalEntity;
        m.FkTown = entitiesModel.FkTown;
        using (var db = new AppDbContext())
        {
            m.Town = db.Towns.Find(entitiesModel.FkTown).Name;
        }
        return m;
    }
}