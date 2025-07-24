using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        public required int Capacity { get; set; }
        public int TeamId { get; set; }
    }
}
