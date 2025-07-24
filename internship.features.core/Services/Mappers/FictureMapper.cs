using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class FictureMapper
{
    public static DbFicture ToEntity(Ficture model)
    {
        return new DbFicture
        {
            Id = model.Id,
            HomeTeamId = model.HomeTeamId,
            AwayTeamId = model.AwayTeamId,
            StadiumId = model.StadiumId,
            RefereeId = model.RefereeId,
            TournamentId = model.TournamentId,
            Tickets = model.Tickets,
        };
    }

    public static Ficture ToModel(DbFicture entity)
    {
        return new Ficture
        {
            Id = entity.Id,
            HomeTeamId = entity.HomeTeamId,
            AwayTeamId = entity.AwayTeamId,
            StadiumId = entity.StadiumId,
            RefereeId = entity.RefereeId,
            Tickets = entity.Tickets,
            TournamentId = entity.TournamentId
        };
    }
}

