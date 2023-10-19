namespace PIS_Vaccination_PI_21_03.Source.Models;

public class TownsServiceEntitiesModels
{
    public int Id { get; set; }
    public int FkTown { get; set; }
    public TownEntitiesModel Town { get; set; }
    public int FkService { get; set; }
    public int Price { get; set; }
}