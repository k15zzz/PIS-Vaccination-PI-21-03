using System.ComponentModel.DataAnnotations.Schema;
using PIS_Vaccination_PI_21_03.Source.Models.ViewModels;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Models;

[Table("animal")]
public class AnimalEntitiesModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("reg_num")]
    public long? RegNum { get; set; }
    [Column("sex")]
    public bool? Sex { get; set; }
    [Column("year_birth")]
    public DateTime YearBirth { get; set; }
    [Column("electronic_chip_number")]
    public string? ElectronicChipNumber { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("photos")]
    public string? Photos { get; set; }
    [Column("special_marks")]
    public string? SpecialMarks { get; set; }
    [Column("fk_town")]
    public int FkTown { get; set; }
    [ForeignKey("FkTown")]
    public TownEntitiesModel Town { get; set; }
    [Column("fk_animal_category")]
    public int FkAnimalCategory { get; set; }
    [ForeignKey("FkAnimalCategory")]
    public AnimalCategoryEntitiesModel AnimalCategory { get; set; }

    public static implicit operator AnimalEntitiesModel(AnimalViewModel viewModel)
    {
        AnimalEntitiesModel _entetyModel = new AnimalEntitiesModel();
        _entetyModel.Id = viewModel.Id;
        _entetyModel.RegNum = viewModel.RegNum;
        _entetyModel.Sex = viewModel.Sex;
        _entetyModel.YearBirth = DateTime.SpecifyKind(viewModel.YearBirth, DateTimeKind.Utc);
        _entetyModel.ElectronicChipNumber = viewModel.ElectronicChipNumber;
        _entetyModel.Name = viewModel.Name;
        _entetyModel.Photos = viewModel.Photos;
        _entetyModel.SpecialMarks = viewModel.SpecialMarks;
        _entetyModel.FkAnimalCategory = viewModel.FkAnimalCategory;
        _entetyModel.FkTown = viewModel.FkTown;
        return _entetyModel;
    }
}