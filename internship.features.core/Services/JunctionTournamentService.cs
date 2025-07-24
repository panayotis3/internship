using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

namespace internship.features.core.Services
{
    public class JunctionTournamentService : IJunctionTournamentService
    {
        private readonly AppDbContext _context;

        public JunctionTournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateJunctionTournamentAsync(JunctionTournament JunctionTournament)
        {
            var vJunctionTournament = JunctionTournamentMapper.ToEntity(JunctionTournament);
            vJunctionTournament.Id = 0;
            _context.JunctionTournaments.Add(vJunctionTournament);
            await _context.SaveChangesAsync();
        }
    }
}
