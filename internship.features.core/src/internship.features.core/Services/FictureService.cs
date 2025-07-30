using Data;
using internship.features.core.Models;
using internship.features.core.Services.Abstractions;
using internship.features.core.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace internship.features.core.Services
{
    public class FictureService : IFictureService
    {
        private readonly AppDbContext _context;

        public FictureService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateFictureAsync(Ficture ficture)
        {
            var vFicture = FictureMapper.ToEntity(ficture);
            vFicture.Id = 0;
            _context.Fictures.Add(vFicture);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Ficture>> GetAllFicturesAsync()
        {
            var fictures = await _context.Fictures.ToListAsync();
            return fictures.Select(FictureMapper.FromEntity).ToList();
        }
        public async Task<Ficture?> GetFictureByIdAsync(int id)
        {
            var ficture = await _context.Fictures.FindAsync(id);
            return ficture != null ? FictureMapper.FromEntity(ficture) : null;
        }
    }
}
