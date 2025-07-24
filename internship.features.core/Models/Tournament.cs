using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(10)]
        public required string Year { get; set; }
    }
}
