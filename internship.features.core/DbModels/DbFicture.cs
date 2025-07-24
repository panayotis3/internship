namespace internship.features.core.DbModels
{
    public class DbFicture
    {
        public required int Id { get; set; }
        public int RefereeId { get; set; }
        public int TournamentId { get; set; }
        public required int Tickets { get; set; }
        public int StadiumId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DbReferee Referee { get; set; } = null!;
        public DbTournament Tournament { get; set; } = null!;
        public DbStadium Stadium { get; set; } = null!;
        public DbTeam HomeTeam { get; set; } = null!;
        public DbTeam AwayTeam { get; set; } = null!;
    }
}
