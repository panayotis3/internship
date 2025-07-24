namespace internship.features.core.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        public int FictureId { get; set; }
        public int ScoringTeamId { get; set; }
        public int Minute { get; set; }
    }
}
