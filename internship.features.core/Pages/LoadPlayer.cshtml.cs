using internship.features.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace internship.features.core.Pages
{
    public class LPlayerModel : PageModel
    {
        private readonly ITeamMemberService _teammemberService;
        private readonly IPersonService _personService;

        public LPlayerModel(ITeamMemberService teammemberService, IPersonService personService)
        {
            _teammemberService = teammemberService;
            _personService = personService;
        }
        public List<TeamMember> Players { get; set; } = new();
        public List<Person?> Persons { get; set; } = new();
        public List<int> personids { get; set; } = new();
        public async Task<IActionResult> OnGetAsync()
        {
            Players = await _teammemberService.GetAllTeamMembersAsync();
            personids = Players.Select(p => p.PersonId).ToList();

            
            foreach (var id in personids)
            {
                var person = await _personService.GetPersonByIdAsync(id);
                if (person != null)
                {
                    Persons.Add(person);
                }
            }


            return Page();
        }


    }
}
