using internship.features.core.DbModels;
using internship.features.core.Models;
namespace internship.features.core.Services.Mappers;
public static class StadiumMapper
{
    public static DbStadium ToEntity(Stadium model)
    {
        return new DbStadium
        {
            Id = model.Id,
            Name = model.Name,
            Capacity = model.Capacity,
            TeamId = model.TeamId
        };
    }

    public static Stadium ToModel(DbStadium entity)
    {
        return new Stadium
        {
            Id = entity.Id,
            Name = entity.Name,
            Capacity = entity.Capacity,
            TeamId = entity.TeamId
        };
    }
}
