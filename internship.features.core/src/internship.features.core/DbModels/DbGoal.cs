namespace internship.features.core.DbModels
{
    public class DbGoal
    {
        public required int Id { get; set; }
        public int TeamMemberId { get; set; }
        public int FictureId { get; set; }
        public int ScoringTeamId { get; set; }
        public int Minute { get; set; }
        public DbTeamMember TeamMember { get; set; } = null!;
        public DbFicture Ficture { get; set; } = null!;
        public DbTeam ScoringTeam { get; set; } = null!;
    }
}
