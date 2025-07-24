using internship.features.core.Models;

namespace internship.features.core.Services
{
    public interface ICardService
    {
        Task CreateCardAsync(Card card);
    }
}
