namespace internship.features.core.DbModels
{
    public class DbJunctionTournament
    {
        public required int Id { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public DbTournament Tournament { get; set; } = null!;
        public DbTeam Team { get; set; } = null!;
    }
}
