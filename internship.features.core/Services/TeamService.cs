using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace internship.features.core.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateTeamAsync(Team team)
        {
            var vTeam = TeamMapper.ToEntity(team);
            vTeam.Id = 0;
            _context.Teams.Add(vTeam);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams.Select(TeamMapper.FromEntity).ToList();
        }

        public async Task DeleteTeamAsync(List<int> teamIds)
        {
            var teamsToDelete = await _context.Teams
                .Where(t => teamIds.Contains(t.Id))
                .ToListAsync();

            if (teamsToDelete.Any())
            {
                _context.Teams.RemoveRange(teamsToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTeamAsync(Team team)
        {
            var existingTeam = await _context.Teams.FindAsync(team.Id);
            if (existingTeam != null)
            {
                existingTeam.Name = team.Name;
                existingTeam.City = team.City;
                existingTeam.Country = team.Country;
                _context.Teams.Update(existingTeam);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            return team != null ? TeamMapper.FromEntity(team) : null;
        }
    }
}
