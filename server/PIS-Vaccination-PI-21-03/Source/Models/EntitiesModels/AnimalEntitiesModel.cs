using System.ComponentModel.DataAnnotations.Schema;

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
}