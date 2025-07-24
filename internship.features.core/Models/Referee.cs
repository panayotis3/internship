using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class Referee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        [MaxLength(10)]
        public required string Type { get; set; }
    }
}
