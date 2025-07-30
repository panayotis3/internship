using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Card>> GetCardsByFictureIdAsync(int fictureId)
        {
            var cards = await _context.Cards
                .Where(c => c.FictureId == fictureId)
                .ToListAsync();
            return cards.Select(CardMapper.ToModel).ToList();
        }
    }
}
