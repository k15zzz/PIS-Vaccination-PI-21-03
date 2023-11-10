namespace PIS_Vaccination_PI_21_03.Source.Models.ViewModels;

public class AnimalViewModel
{
    public int Id { get; set; }
    public long? RegNum { get; set; }
    public bool? Category { get; set; }
    public bool? Sex { get; set; }
    public DateTime? YearBirth { get; set; }
    public string? ElectronicChipNumber { get; set; }
    public string? Name { get; set; }
    public string? Photos { get; set; }
    public string? SpecialMarks { get; set; }
    public int FkTown { get; set; }
}