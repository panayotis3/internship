using internship.features.core.Models;

namespace internship.features.core.Services.Abstractions
{
    public interface ITournamentService
    {
        Task CreateTournamentAsync(Tournament tournament);
        Task<List<Tournament>> GetAllTournamentsAsync();
        Task<Tournament?> GetTournamentByIdAsync(int id);
    }
}
