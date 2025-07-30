using internship.features.core.Models;

namespace internship.features.core.Services.Abstractions
{
    public interface ICardService
    {
        Task CreateCardAsync(Card card);
        Task<List<Card>> GetCardsByFictureIdAsync(int fictureId);
    }
}
