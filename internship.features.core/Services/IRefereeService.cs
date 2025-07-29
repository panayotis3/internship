using internship.features.core.Models;

namespace internship.features.core.Services
{
    public interface IRefereeService
    {
        Task CreateRefereeAsync(Referee referee);
        Task<Referee?> GetRefereeByIdAsync(int id);
    }
}
