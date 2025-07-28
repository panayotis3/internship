using internship.features.core.Models;

namespace internship.features.core.Services
{
    public interface ITournamentService
    {
        Task CreateTournamentAsync(Tournament tournament);
        Task<List<Tournament>> GetAllTournamentsAsync();
        Task<Tournament?> GetTournamentByIdAsync(int id);
    }
}
