using System.ComponentModel.DataAnnotations;

namespace internship.features.core.DbModels
{
    public class DbTournament
    {
        public required int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(10)]
        public required string Year { get; set; }
    }
}
