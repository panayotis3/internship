using Data;
using internship.features.core.Models;
using internship.features.core.Services.Abstractions;
using internship.features.core.Services.Mappers;

namespace internship.features.core.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            var vPerson = PersonMapper.ToEntity(person);
            _context.Persons.Add(vPerson);
            await _context.SaveChangesAsync();

            return PersonMapper.ToModel(vPerson); 
        }
        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            return person != null ? PersonMapper.FromEntity(person) : null;
        }
        public async Task<Person?> UpdatePersonAsync(Person person)
        {
            var existingPerson = await _context.Persons.FindAsync(person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.DateOfBirth = person.DateOfBirth;
                existingPerson.Nationality = person.Nationality;
                await _context.SaveChangesAsync();
            }
            return existingPerson != null ? PersonMapper.FromEntity(existingPerson) : null;
        }
    }
}



