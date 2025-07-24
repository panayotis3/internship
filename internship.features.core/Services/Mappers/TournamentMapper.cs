using internship.features.core.DbModels;
using internship.features.core.Models;
namespace internship.features.core.Services.Mappers;
public static class TournamentMapper
{
    public static DbTournament ToEntity(Tournament model)
    {
        return new DbTournament
        {
            Id = model.Id,
            Name = model.Name,
            Year = model.Year
        };
    }

    public static Tournament ToModel(DbTournament entity)
    {
        return new Tournament
        {
            Id = entity.Id,
            Name = entity.Name,
            Year = entity.Year
        };
    }
}

