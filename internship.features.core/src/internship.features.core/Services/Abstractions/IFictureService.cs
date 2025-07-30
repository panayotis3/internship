using internship.features.core.Models;
namespace internship.features.core.Services.Abstractions
{
    public interface IFictureService
    {
        Task CreateFictureAsync(Ficture ficture);
        Task<List<Ficture>> GetAllFicturesAsync();
        Task<Ficture?> GetFictureByIdAsync(int id);
    }
}
