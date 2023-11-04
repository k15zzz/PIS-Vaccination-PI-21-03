using PIS_Vaccination_PI_21_03.Source.Models;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public class AnimalRepository: IRepository<AnimalEntitiesModel>
{
    public Task<int> CreateAsync(AnimalEntitiesModel model)
    {
        throw new NotImplementedException();
    }

    public Task<List<AnimalEntitiesModel>> ReadTableAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AnimalEntitiesModel> ReadItemAsync(int id)
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