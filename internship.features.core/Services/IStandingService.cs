using internship.features.core.Models;
namespace internship.features.core.Services
{
    public interface IStandingService
    {
        Task CreateStandingAsync(Standing standing);
        Task<Standing?> GetStandingByIdAsync(int id);
        Task<List<Standing>> GetStandingsByJunctionTournamentIdAsync(int junctiontournamentId);
    }
}
