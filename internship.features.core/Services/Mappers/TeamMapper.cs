using internship.features.core.DbModels;
using internship.features.core.Models;

namespace internship.features.core.Services.Mappers
{
    public static class TeamMapper
    {
        public static DbTeam ToEntity(Team model)
        {
            return new DbTeam
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                Country = model.Country
            };
        }
        public static Team FromEntity(DbTeam dbModel)
        {
            return new Team
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                City = dbModel.City,
                Country = dbModel.Country
            };
        }

        public static Team ToModel(DbTeam entity)
        {
            return new Team
            {
                Id = entity.Id,
                Name = entity.Name,
                City = entity.City,
                Country = entity.Country
            };
        }
    }
}
