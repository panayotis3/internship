using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace internship.features.core.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly AppDbContext _context;

        public StadiumService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStadiumAsync(Stadium stadium)
        {
            var vStadium = StadiumMapper.ToEntity(stadium);
            vStadium.Id = 0;
            _context.Stadiums.Add(vStadium);
            await _context.SaveChangesAsync();
        }
        public async Task<Stadium?> GetStadiumByTeamIdAsync(int teamId)
        {
            var stadium = await _context.Stadiums
                .Where(s => s.TeamId == teamId)
                .FirstOrDefaultAsync();
            if (stadium != null)
            {
                return StadiumMapper.ToModel(stadium);
            }
            return null;
        }
        public async Task<Stadium?> GetStadiumByIdAsync(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            return stadium != null ? StadiumMapper.ToModel(stadium) : null;
        }
    }
}

