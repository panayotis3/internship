using internship.features.core.Models;
using internship.features.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace internship.features.core.Pages
{

    public class DPlayerModel : PageModel
    {
        private readonly ITeamMemberService _teammemberService;
        private readonly IPersonService _personService;

        public DPlayerModel(ITeamMemberService teammemberService, IPersonService personService)
        {
            _teammemberService = teammemberService;
            _personService = personService;
        }
        [BindProperty]
        public List<int> SelectedPlayerIds { get; set; } = new();
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!SelectedPlayerIds.Any())
            {
                ModelState.AddModelError(string.Empty, "Please select at least one player to delete.");

               
                await OnGetAsync();
                return Page();
            }

            
            var allplayers = await _teammemberService.GetAllPlayersAsync();
            var playersToDelete = allplayers
                .Where(tm => SelectedPlayerIds.Contains(tm.PersonId))
                .Select(tm => tm.Id)  
                .ToList();

            await _teammemberService.DeleteTeamMemberAsync(playersToDelete);
            return RedirectToPage();
        }
    }

}
