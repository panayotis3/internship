using internship.features.core.Models;

namespace internship.features.core.Services
{
    public interface IJunctionTournamentService
    {
        Task CreateJunctionTournamentAsync(JunctionTournament junctiontournament);
    }
}
