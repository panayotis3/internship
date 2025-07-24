using internship.features.core.Models;
namespace internship.features.core.Services
{
    public interface IStandingService
    {
        Task CreateStandingAsync(Standing standing);
    }
}
