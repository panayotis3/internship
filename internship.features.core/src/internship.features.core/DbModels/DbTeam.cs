using System.ComponentModel.DataAnnotations;
using internship.features.core.Models;

namespace internship.features.core.DbModels
{
    public class DbTeam
    {
        public required int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(10)]
        public required string City { get; set; }
        [MaxLength(10)]
        public required string Country { get; set; }
       
    }
}
