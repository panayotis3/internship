namespace internship.features.core.Models
{
    public class Ficture
    {
        public int Id { get; set; }
        public int RefereeId { get; set; }
        public int TournamentId { get; set; }
        public required int Tickets { get; set; }
        public int StadiumId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}
