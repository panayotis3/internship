using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class StandingMapper
{
    public static DbStanding ToEntity(Standing model)
    {
        return new DbStanding
        {
            Id = model.Id,
            JunctionTournamentId = model.JunctionTournamentId,
            Matches = model.Matches,
            Won = model.Won,
            Lost = model.Lost,
            Draw = model.Draw
        };
    }

    public static Standing ToModel(DbStanding entity)
    {
        return new Standing
        {
            Id = entity.Id,
            JunctionTournamentId = entity.JunctionTournamentId,
            Matches = entity.Matches,
            Won = entity.Won,
            Lost = entity.Lost,
            Draw = entity.Draw
        };
    }
}

