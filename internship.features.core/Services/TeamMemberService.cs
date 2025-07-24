using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace internship.features.core.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly AppDbContext _context;

        public TeamMemberService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateTeamMemberAsync(TeamMember teammember)
        {
            var vTeamMember = TeamMemberMapper.ToEntity(teammember);
            vTeamMember.Id = 0;
            _context.TeamMembers.Add(vTeamMember);
            await _context.SaveChangesAsync();
        }
        public async Task<List<TeamMember>> GetAllPlayersAsync()
        {
            var teammembers = await _context.TeamMembers
                .Where(tm => tm.Type == "Player")
                .Include(pd => pd.Person)
                .ToListAsync();
            return teammembers.Select(TeamMemberMapper.FromEntity).ToList();
        }
        public async Task<List<TeamMember>> GetAllTeamMembersAsync()
        {
            var teammembers = await _context.TeamMembers.ToListAsync();
            return teammembers.Select(TeamMemberMapper.FromEntity).ToList();
        }
        public async Task DeleteTeamMemberAsync(List<int> teammemberIds)
        {
            var teammembersToDelete = await _context.TeamMembers
                .Where(t => teammemberIds.Contains(t.Id))
                .ToListAsync();

            if (teammembersToDelete.Any())
            {
                _context.TeamMembers.RemoveRange(teammembersToDelete);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateTeamMemberAsync(TeamMember teammember)
        {
            var existingMember = await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.Id == teammember.Id);
            if (existingMember != null)
            {
                existingMember.TeamId = teammember.TeamId;
                existingMember.Period = teammember.Period;
                existingMember.Type = teammember.Type;
                await _context.SaveChangesAsync();
            }
            }
    }
}
