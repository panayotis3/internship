using Data;
using internship.features.core.Models;
using internship.features.core.Services.Mappers;

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
    }
}
