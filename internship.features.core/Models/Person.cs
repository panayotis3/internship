using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(10)]
        public required string DateOfBirth { get; set; }
        [MaxLength(10)]
        public required string Nationality { get; set; }
    

    }
}
