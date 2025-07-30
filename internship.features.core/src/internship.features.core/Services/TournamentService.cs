using Data;
using internship.features.core.Models;
using internship.features.core.Services.Abstractions;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Tournament>> GetAllTournamentsAsync()
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return tournaments.Select(TournamentMapper.FromEntity).ToList();
        }
        public async Task<Tournament?> GetTournamentByIdAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            return tournament != null ? TournamentMapper.FromEntity(tournament) : null;
        }
    }
}
