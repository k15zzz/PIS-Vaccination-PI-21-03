using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class AnimalViewModel
{
    public int Id { get; set; }
    public long? RegNum { get; set; }
    public bool? Sex { get; set; }
    public DateTime YearBirth { get; set; }
    public string? ElectronicChipNumber { get; set; }
    public string? Name { get; set; }
    public string? Photos { get; set; }
    public string? SpecialMarks { get; set; }
    public int FkAnimalCategory { get; set; }
    public int FkTown { get; set; }
    public string? AnimalCategory { get; set; }
    public string? Town { get; set; }
    
    public static implicit operator AnimalViewModel(AnimalEntitiesModel entitiesModel)
    {
        var m = new AnimalViewModel();
        m.Id = entitiesModel.Id;
        m.RegNum = entitiesModel.RegNum;
        m.Sex = entitiesModel.Sex;
        m.YearBirth = entitiesModel.YearBirth;
        m.FkAnimalCategory = entitiesModel.FkAnimalCategory;
        m.ElectronicChipNumber = entitiesModel.ElectronicChipNumber;
        m.Name = entitiesModel.Name;
        m.Photos = entitiesModel.Photos;
        m.SpecialMarks = entitiesModel.SpecialMarks;
        m.FkTown = entitiesModel.FkTown;
        using (var db = new AppDbContext())
        {
            m.AnimalCategory = db.AnimalCategory.Find(entitiesModel.FkAnimalCategory).Name;
            m.Town = db.Towns.Find(entitiesModel.FkTown).Name;
        }
        return m;
    }
}