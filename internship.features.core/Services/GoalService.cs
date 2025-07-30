using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace internship.features.core.Services
{
    public class GoalService : IGoalService
    {
        private readonly AppDbContext _context;

        public GoalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateGoalAsync(Goal Goal)
        {
            var vGoal = GoalMapper.ToEntity(Goal);
            vGoal.Id = 0;
            _context.Goals.Add(vGoal);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Goal>> GetGoalsByFictureIdAsync(int fictureId)
        {
            var goals = await _context.Goals
                .Where(g => g.FictureId == fictureId)
                .ToListAsync();
            return goals.Select(GoalMapper.ToModel).ToList();
        }
    }
}