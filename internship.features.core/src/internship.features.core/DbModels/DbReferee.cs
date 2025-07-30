using System.ComponentModel.DataAnnotations;
using internship.features.core.Models;

namespace internship.features.core.DbModels
{
    public class DbReferee
    {
        public required int Id { get; set; }
        public int PersonId { get; set; }
        [MaxLength(10)]
        public required string Type { get; set; }
        public DbPerson Person { get; set; } = null!;
    }
}
