using System.ComponentModel.DataAnnotations;

namespace internship.features.core.DbModels
{
    public class DbStadium
    {       
        public required int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        public required int Capacity { get; set; }
        public int TeamId { get; set; }
        public DbTeam Team { get; set; } = null!;
    }
}
