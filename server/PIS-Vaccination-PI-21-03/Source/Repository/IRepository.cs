using Microsoft.AspNetCore.Mvc;

namespace PIS_Vaccination_PI_21_03.Source.Repository;

public interface IRepository <T>
{
    public int     CreateAsync     (T model);
    public Task<List<T>> ReadTableAsync  ();
    public Task<T>       ReadItemAsync   (int id);
    public void          UpdateAsync     (int id, JsonContent model);
    public void          DeleteAsync (int id);
}