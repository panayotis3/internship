using internship.features.core.Models;

public interface ITeamService
{
    Task CreateTeamAsync(Team team);
    Task<List<Team>> GetAllTeamsAsync();
    Task DeleteTeamAsync(List<int> teamIds);
    Task UpdateTeamAsync(Team team);
    Task<Team?> GetTeamByIdAsync(int id);
}
