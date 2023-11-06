﻿namespace PIS_Vaccination_PI_21_03.Source.Repository;

public interface IRepository <T>
{
    public int     CreateAsync     (JsonContent model);
    public Task<List<T>> ReadTableAsync  ();
    public Task<T>       ReadItemAsync   (int id);
    public Task          UpdateAsync     (int bookId, JsonContent UpdatedModel);
    public Task          DeleteAsync (int bookId);
}
//кринге
//мы старались 0_0