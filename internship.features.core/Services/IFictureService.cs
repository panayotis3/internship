using internship.features.core.Models;
namespace internship.features.core.Services
{
    public interface IFictureService
    {
        Task CreateFictureAsync(Ficture ficture);
        Task<List<Ficture>> GetAllFicturesAsync();
    }
}
