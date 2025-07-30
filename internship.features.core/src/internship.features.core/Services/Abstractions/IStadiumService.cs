using internship.features.core.Models;

namespace internship.features.core.Services.Abstractions
{
    public interface IStadiumService
    {
        Task CreateStadiumAsync(Stadium stadium);
        Task<Stadium?> GetStadiumByTeamIdAsync(int teamid);
        Task<Stadium?> GetStadiumByIdAsync(int id);
    }
}