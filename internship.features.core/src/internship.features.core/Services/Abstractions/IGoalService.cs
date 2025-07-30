using internship.features.core.Models;

namespace internship.features.core.Services.Abstractions
{
    public interface IGoalService
    {
        Task CreateGoalAsync(Goal goal);
        Task<List<Goal>> GetGoalsByFictureIdAsync(int fictureId);
    }
}
