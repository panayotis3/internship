using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

namespace internship.features.core.Services
{
    public class RefereeService : IRefereeService
    {
        private readonly AppDbContext _context;

        public RefereeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRefereeAsync(Referee referee)
        {
            var vReferee = RefereeMapper.ToEntity(referee);
            vReferee.Id = 0;
            _context.Referees.Add(vReferee);
            await _context.SaveChangesAsync();
        }
        public async Task<Referee?> GetRefereeByIdAsync(int id)
        {
            var referee = await _context.Referees.FindAsync(id);
            return referee != null ? RefereeMapper.FromEntity(referee) : null;
        }
    }
}
