using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class VaccinationRepository : IRepository<VaccinationEntitiesModel>
{
    public Task<int> CreateAsync(VaccinationEntitiesModel model)
    {
        throw new NotImplementedException();
    }

    public Task<List<VaccinationEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<VaccinationEntitiesModel> ReadItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int bookId, JsonContent bookModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}