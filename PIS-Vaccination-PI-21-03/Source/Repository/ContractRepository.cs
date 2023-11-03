using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class ContractRepository:IRepository<ContractEntitiesModel>
{
    public Task<int> CreateAsync(ContractEntitiesModel model)
    {
        throw new NotImplementedException();
    }

    public Task<List<ContractEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ContractEntitiesModel> ReadItemAsync(int id)
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