using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class Team
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(10)]
        public required string City { get; set; }
        [MaxLength(10)]
        public required string Country { get; set; }
    }
}
