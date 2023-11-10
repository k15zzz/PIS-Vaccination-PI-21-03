﻿using System.Text.Json;
using PIS_Vaccination_PI_21_03.Source;
using PIS_Vaccination_PI_21_03.Source.Models;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI21_03.Tests.Repository.Tests;


[TestFixture]
public class CreateAnimal_Test
{
    [SetUp]
    public void SetUp()
    { }

    string normalJSONwithTownName = "{\"RegNum\":123456," + 
                                         "\"Category\":true," + 
                                         "\"Sex\":true," + 
                                         "\"YearBitrh\":\"12.12.2020\"," + 
                                         "\"ElectronicChipNumber\":\"123-123\"," + 
                                         "\"Name\":\"Кошак\"," + 
                                         "\"Photos\":\"Фото кота, красива\"," + 
                                         "\"FkTown\":\"Тюмень\"}";
    string normalJSONwithTownId = "{\"RegNum\":123456," +
                                  "\"Category\":true," +
                                  "\"Sex\":true," +
                                  "\"YearBitrh\":\"12.12.2020\"," +
                                  "\"ElectronicChipNumber\":\"123-123\"," +
                                  "\"Name\":\"Кошак\"," +
                                  "\"Photos\": \"Фото кота, красива\"," +
                                  "\"FkTown\":1}";
    string emptyJSON = "{}";
    string noneJSON = "{\"RegNum\":," +
                      "\"Category\":," +
                      "\"Sex\":," +
                      "\"YearBitrh\":," +
                      "\"ElectronicChipNumber\":," +
                      "\"Name\":," +
                      "\"Photos\":" +
                      "\"FkTown\":}";

    [Test]
    public void ConnectionToDb() =>
           Assert.True( new AppDbContext().Database.CanConnect());
    
    [Test]
    public void NormalJSONwithTownName()
    {
        var repository = new AnimalRepository();
        var retunedId = repository.CreateAsync(JsonSerializer.Deserialize<AnimalEntitiesModel>(normalJSONwithTownName));
        Assert.NotNull(retunedId);
    }
    
    [Test]
    public void NormalJSONwithTownId()
    {
        var repository = new AnimalRepository();
        var retunedId = repository.CreateAsync(JsonSerializer.Deserialize<AnimalEntitiesModel>(normalJSONwithTownId));
        Assert.NotNull(retunedId);
    }

    [Test]
    public void EmptyJSON()
    {
        var repository = new AnimalRepository();
        var retunedId = repository.CreateAsync(JsonSerializer.Deserialize<AnimalEntitiesModel>(emptyJSON));
        Assert.NotNull(retunedId);
    }

    [Test]
    public void NoneJSON()
    {
        var repository = new AnimalRepository();
        var retunedId = repository.CreateAsync(JsonSerializer.Deserialize<AnimalEntitiesModel>(noneJSON));
        Assert.NotNull(retunedId);
    }
}