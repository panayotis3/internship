using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class RefereeMapper
{
    public static DbReferee ToEntity(Referee model)
    {
        return new DbReferee
        {
            Id = model.Id,
            Type = model.Type,
            PersonId = model.PersonId,
        };
    }

    public static Referee ToModel(DbReferee entity)
    {
        return new Referee
        {
            Id = entity.Id,
            Type = entity.Type,
            PersonId = entity.PersonId,
            
        };
    }
}

