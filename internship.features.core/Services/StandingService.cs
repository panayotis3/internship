using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace internship.features.core.Services
{
    public class StandingService : IStandingService
    {
        private readonly AppDbContext _context;

        public StandingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStandingAsync(Standing Standing)
        {
            var vStanding = StandingMapper.ToEntity(Standing);
            vStanding.Id = 0;
            _context.Standings.Add(vStanding);
            await _context.SaveChangesAsync();
        }
        public async Task<Standing?> GetStandingByIdAsync(int id)
        {
            var standing = await _context.Standings.FindAsync(id);
            return standing != null ? StandingMapper.FromEntity(standing) : null;
        }
        public async Task<List<Standing>> GetStandingsByJunctionTournamentIdAsync(int junctiontournamentId)
        {
            var standings = await _context.Standings
                .Where(s => s.JunctionTournamentId == junctiontournamentId)
                .ToListAsync();
            
            return standings.Select(StandingMapper.FromEntity).ToList();
        }
    }
}

