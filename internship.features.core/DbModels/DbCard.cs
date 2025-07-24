using System.ComponentModel.DataAnnotations;

namespace internship.features.core.DbModels
{
    public class DbCard
    {
        
        public required int Id { get; set; }
        public int TeamMemberId { get; set; }
        public int FictureId { get; set; }
        [MaxLength(10)]
        public required string CardType { get; set; }
        public required int Minute { get; set; }
        public DbTeamMember TeamMember { get; set; } = null!;
        public DbFicture Ficture { get; set; } = null!;
    }
}
