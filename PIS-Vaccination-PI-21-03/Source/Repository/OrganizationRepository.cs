using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class OrganizationRepository : IRepository<OrganizationEntitiesModel>
{
    public Task<int> CreateAsync(OrganizationEntitiesModel model)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrganizationEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationEntitiesModel> ReadItemAsync(int id)
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