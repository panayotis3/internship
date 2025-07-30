using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class JunctionTournamentMapper
{
    public static DbJunctionTournament ToEntity(JunctionTournament model)
    {
        return new DbJunctionTournament
        {
            Id = model.Id,
            TeamId = model.TeamId,
            TournamentId = model.TournamentId
        };
    }

    public static JunctionTournament ToModel(DbJunctionTournament entity)
    {
        return new JunctionTournament
        {
            Id = entity.Id,
            TeamId = entity.TeamId,
            TournamentId = entity.TournamentId
        };
    }
    public static JunctionTournament FromEntity(DbJunctionTournament dbModel)
    {
        return new JunctionTournament
        {
            Id = dbModel.Id,
            TournamentId = dbModel.TournamentId,
            TeamId = dbModel.TeamId
        };
    }
}

