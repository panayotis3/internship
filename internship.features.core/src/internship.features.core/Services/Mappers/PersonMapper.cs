using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class PersonMapper
{
    public static DbPerson ToEntity(Person model)
    {
        return new DbPerson
        {
            Id = model.Id,
            Name = model.Name,
            DateOfBirth = model.DateOfBirth,
            Nationality = model.Nationality
        };
    }

    public static Person ToModel(DbPerson entity)
    {
        return new Person
        {
            Id = entity.Id,
            Name = entity.Name,
            Nationality = entity.Nationality,
            DateOfBirth = entity.DateOfBirth
        };
    }
    public static Person FromEntity(DbPerson dbModel)
    {
        return new Person
        {
            Id = dbModel.Id,
            Name = dbModel.Name,
            DateOfBirth = dbModel.DateOfBirth,
            Nationality = dbModel.Nationality
        };
    }
}
