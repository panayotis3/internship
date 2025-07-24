namespace internship.features.core.DbModels
{
    public class DbStanding
    {
        public required int Id { get; set; }
        public int JunctionTournamentId { get; set; }
        public required int Matches { get; set; }
        public required int Won { get; set; }
        public required int Draw { get; set; }
        public required int Lost { get; set; }
        public DbJunctionTournament JunctionTournament { get; set; } = null!;
    }
}
