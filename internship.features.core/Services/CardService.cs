using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

namespace internship.features.core.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;
        public CardService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateCardAsync(Card card)
        {
            var vCard = CardMapper.ToEntity(card);
            vCard.Id = 0;
            _context.Cards.Add(vCard);
            await _context.SaveChangesAsync();
        }
    }
}
