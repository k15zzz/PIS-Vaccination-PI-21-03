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
}