using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

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
    }
}

