namespace internship.features.core.Models
{
    public class JunctionTournament
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public Tournament? Tournament { get; set; }
        public Team? Team { get; set; }
    }
}
