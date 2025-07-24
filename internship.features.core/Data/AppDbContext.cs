using Microsoft.EntityFrameworkCore;
using internship.features.core.DbModels;
namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<DbTeam> Teams { get; set; }
        public DbSet<DbTournament> Tournaments { get; set; }
        public DbSet<DbJunctionTournament> JunctionTournaments { get; set; }
        public DbSet<DbStanding> Standings { get; set; }
        public DbSet<DbStadium> Stadiums { get; set; }
        public DbSet<DbPerson> Persons { get; set; }
        public DbSet<DbReferee> Referees { get; set; }
        public DbSet<DbFicture> Fictures { get; set; }
        public DbSet<DbTeamMember> TeamMembers { get; set; }
        public DbSet<DbGoal> Goals { get; set; }
        public DbSet<DbCard> Cards { get; set; }


        
    }
}