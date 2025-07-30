using internship.features.core.DbModels;
using System.ComponentModel.DataAnnotations;

namespace internship.features.core.DbModels
{
    public class DbTeamMember
    {
        public required int Id { get; set; }
        public int PersonId { get; set; }
        public int TeamId { get; set; }
        [MaxLength(10)]
        public required string Period { get; set; }
        [MaxLength(10)]
        public required string Type { get; set; }
        public DbPerson Person { get; set; } = null!;
        public DbTeam Team { get; set; } = null!;
    }
}