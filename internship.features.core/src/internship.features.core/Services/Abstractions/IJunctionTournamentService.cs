using internship.features.core.Models;

namespace internship.features.core.Services.Abstractions
{
    public interface IJunctionTournamentService
    {
        Task CreateJunctionTournamentAsync(JunctionTournament junctiontournament);
        Task<List<JunctionTournament>> GetJunctionTournamentsByTeamIdAsync(int teamId);
    }
}
