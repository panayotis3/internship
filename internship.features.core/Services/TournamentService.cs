using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

namespace internship.features.core.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateTournamentAsync(Tournament tournament)
        {
            var vTournament = TournamentMapper.ToEntity(tournament);
            vTournament.Id = 0;
            _context.Tournaments.Add(vTournament);
            await _context.SaveChangesAsync();
        }
    }
}
