using Microsoft.EntityFrameworkCore;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Models.DTOModels;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class StatisticRepository
{
    public static List<VaccinationDTO> GetDateStatistic(DateTime dateStart, DateTime dateFinish, List<int> town)
    {

        var result = new List<VaccinationDTO>();

        List<VaccinationEntitiesModel> vactinations;
        using (var db = new AppDbContext())
        { 
            vactinations =  db.Vaccinations
                .Include(v => v.Organization)
                .Include(v => v.Organization.Town)
                .Include(v => v.Organization.Town.TownsService)
                .Where(v => dateStart <= v.Date && v.Date <= dateFinish)
                .Where(v => town.Contains(v.Organization.FkTown))
                .ToList();
        }

        foreach (var vactination in vactinations)
        {
            var idOrg = vactination.FkOrg;

            var idTown = vactination.Organization.FkTown;

            if (town.Contains(idTown))
            {
                var vacDto = new VaccinationDTO();
                vacDto.Id = vactination.Id;
                vacDto.Type = vactination.Type;
                vacDto.Date = vactination.Date;
                vacDto.NumOfSeries = vactination.NumOfSeries;
                vacDto.DateOfExpire = vactination.DateOfExpire;
                vacDto.PositionOfDoc = vactination.PositionOfDoc;
                vacDto.TownName = vactination.Organization.Town.Name;
                vacDto.Price = vactination.Organization.Town.TownsService[0].Price;
                result.Add(vacDto);
            }
        }

        return result;
    }
}