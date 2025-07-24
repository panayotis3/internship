using internship.features.core.Models;
using internship.features.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace internship.features.core.Pages
{
    public class CPlayerModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly ITeamMemberService _teammemberService;
        private readonly IPersonService _personService;

        public CPlayerModel(ITeamService teamService, ITeamMemberService teammemberService, IPersonService personService)
        {
            _teamService = teamService;
            _teammemberService = teammemberService;
            _personService = personService;
        }

        [BindProperty]
        public Person NewPerson { get; set; } = new Person
        {
            Name = string.Empty,
            DateOfBirth = string.Empty,
            Nationality = string.Empty
        };
        
        public TeamMember NewPlayer { get; set; } = new TeamMember
        {
            Type = "Player",
            Period = string.Empty
        };
        [BindProperty]
        public string period { get; set; } = string.Empty;
        [BindProperty]
        public int? TeamId { get; set; }
        public List<Team> Teams { get; set; } = new();


        public List<SelectListItem> TeamOptions { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            TeamOptions = Teams
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                })
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            TeamOptions = Teams
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                })
                .ToList();

            if (!ModelState.IsValid || TeamId == null)
            {
                ModelState.AddModelError(string.Empty, "Please select a valid team and fill in all fields.");
                return Page();
            }

            var existingTeam = await _teamService.GetTeamByIdAsync(TeamId.Value);
            if (existingTeam == null)
            {
                ModelState.AddModelError(string.Empty, "Selected team not found.");
                return Page();
            }


            NewPerson = await _personService.CreatePersonAsync(NewPerson);


            NewPlayer.Period = period;

            NewPlayer.PersonId = NewPerson.Id;
            NewPlayer.TeamId = TeamId.Value;

            await _teammemberService.CreateTeamMemberAsync(NewPlayer);

            return RedirectToPage();
        }


    }
}