using System.ComponentModel.DataAnnotations;

namespace internship.features.core.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        public int FictureId { get; set; }
        [MaxLength(10)]
        public required string CardType { get; set; }
        public required  int Minute { get; set; }
        public TeamMember? TeamMember { get; set; }
        public Ficture? Ficture { get; set; }
    }
}
