namespace PIS_Vaccination_PI_21_03.Source.Repository;

public interface IRepository <T>
{
    public int     CreateAsync     (JsonContent model);
    public Task<List<T>> ReadTableAsync  ();
    public Task<T>       ReadItemAsync   (int id);
    public void          UpdateAsync     (int id, JsonContent model);
    public Task          DeleteAsync (int id);
}
//кринге
//мы старались 0_0