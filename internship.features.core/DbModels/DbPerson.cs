using System.ComponentModel.DataAnnotations;

namespace internship.features.core.DbModels
{
    public class DbPerson
    {
        public required int Id { get; set; }
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(10)]
        public required string DateOfBirth { get; set; }
        [MaxLength(10)]
        public required string Nationality { get; set; }
    }
}
