using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class CardMapper
{
    public static DbCard ToEntity(Card model)
    {
        return new DbCard
        {
            Id = model.Id,
            TeamMemberId = model.TeamMemberId,
            FictureId = model.FictureId,
            CardType = model.CardType,
            Minute = model.Minute

        };
    }

    public static Card ToModel(DbCard entity)
    {
        return new Card
        {
            Id = entity.Id,
            CardType = entity.CardType,
            TeamMemberId = entity.TeamMemberId,
            FictureId = entity.FictureId,
            Minute = entity.Minute
        };
    }
}

