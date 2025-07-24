using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int TeamId { get; set; }
        [MaxLength(10)]
        public required string Period { get; set; }
        [MaxLength(10)]
        public required string Type { get; set; }
    }
}
