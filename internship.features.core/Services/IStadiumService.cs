using internship.features.core.Models;

namespace internship.features.core.Services
{
    public interface IStadiumService
    {
        Task CreateStadiumAsync(Stadium stadium);
        Task<Stadium?> GetStadiumByTeamIdAsync(int teamid);
    }
}