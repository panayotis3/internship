using internship.features.core.Models;
using internship.features.core.DbModels;

namespace internship.features.core.Services.Mappers;

public class TeamMemberMapper
{
    public static DbTeamMember ToEntity(TeamMember model)
    {
        return new DbTeamMember
        {
            Id = model.Id,
            PersonId = model.PersonId,
            TeamId = model.TeamId,
            Type = model.Type,
            Period = model.Period
        };
    }
    public static TeamMember ToModel(DbTeamMember entity)
    {
        return new TeamMember
        {
            Id = entity.Id,
            PersonId = entity.PersonId,
            TeamId = entity.TeamId,
            Type = entity.Type,
            Period = entity.Period
        };
    }
    public static TeamMember FromEntity(DbTeamMember dbModel)
    {
        return new TeamMember
        {
            Id = dbModel.Id,
            PersonId = dbModel.PersonId,
            TeamId = dbModel.TeamId,
            Period = dbModel.Period,
            Type = dbModel.Type
        };
    }
}
