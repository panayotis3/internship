using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

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
    }
}

