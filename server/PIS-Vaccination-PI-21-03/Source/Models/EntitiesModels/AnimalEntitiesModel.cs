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
    [Column("category")]
    public bool? Category { get; set; }
    [Column("sex")]
    public bool? Sex { get; set; }
    [Column("year_birth")]
    public DateTime? YearBirth { get; set; }
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

    public static implicit operator AnimalEntitiesModel(AnimalViewModel viewNodel)
    {
        AnimalEntitiesModel _entetyModel = new AnimalEntitiesModel();
        _entetyModel.RegNum = viewNodel.RegNum;
        _entetyModel.Category = viewNodel.Category;
        _entetyModel.Sex = viewNodel.Sex;
        _entetyModel.YearBirth = viewNodel.YearBirth;
        _entetyModel.ElectronicChipNumber = viewNodel.ElectronicChipNumber;
        _entetyModel.Name = viewNodel.Name;
        _entetyModel.Photos = viewNodel.Photos;
        _entetyModel.SpecialMarks = viewNodel.SpecialMarks;
        _entetyModel.FkTown = viewNodel.FkTown;
        using (var context = new AppDbContext())
        {
            _entetyModel.Town = context.Towns.Find(viewNodel.FkTown);
        }
        return _entetyModel;
    }
}