using internship.features.core.Models;

namespace internship.features.core.Services.Abstractions
{
    public interface IPersonService
    {
        Task<Person> CreatePersonAsync(Person person);
        Task<Person?> GetPersonByIdAsync(int id);
        Task<Person?> UpdatePersonAsync(Person person);
    }
}

