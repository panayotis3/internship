using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers;

public static class GoalMapper
{
    public static DbGoal ToEntity(Goal model)
    {
        return new DbGoal
        {
            Id = model.Id,
            TeamMemberId = model.TeamMemberId,
            FictureId = model.FictureId,
            ScoringTeamId = model.ScoringTeamId,
            Minute = model.Minute,
        };
    }

    public static Goal ToModel(DbGoal entity)
    {
        return new Goal
        {
            Id = entity.Id,
            TeamMemberId = entity.TeamMemberId,
            FictureId = entity.FictureId,
            ScoringTeamId = entity.ScoringTeamId,
            Minute = entity.Minute,
        };
    }
}

