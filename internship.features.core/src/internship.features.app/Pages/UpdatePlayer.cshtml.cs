using internship.features.core.Models;
using internship.features.core.Services;
using internship.features.core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace internship.features.core.Pages
{
    public class UPlayerModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly ITeamMemberService _teammemberService;
        private readonly IPersonService _personService;

        public UPlayerModel(ITeamService teamService, ITeamMemberService teammemberService, IPersonService personService)
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
        [BindProperty]
        public string period { get; set; } = string.Empty;
        [BindProperty]
        public string type { get; set; } = string.Empty;
        public TeamMember NewPlayer { get; set; } = new TeamMember
        {
            Type = string.Empty,
            Period = string.Empty
        };
        [BindProperty]
        public int? TeamId { get; set; }
        [BindProperty]
        public int SelectedPlayerId { get; set; }
        public List<Team> Teams { get; set; } = new();
        public List<TeamMember> Players { get; set; } = new();
        public List<SelectListItem> TeamOptions { get; set; } = new();
        public List<SelectListItem> PlayerOptions { get; set; } = new();
        public List<Person?> Persons { get; set; } = new();
        public List<int> personids { get; set; } = new();
        public async Task<IActionResult> OnGetAsync()
        {
            Players = await _teammemberService.GetAllPlayersAsync();
            personids = Players.Select(p => p.PersonId).ToList();


            foreach (var id in personids)
            {
                var person = await _personService.GetPersonByIdAsync(id);
                if (person != null)
                {
                    Persons.Add(person);
                }
            }
            PlayerOptions = Persons
                .Select(p => new SelectListItem
                {
                    Value = p!.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

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
            Players = await _teammemberService.GetAllPlayersAsync();
            personids = Players.Select(p => p.PersonId).ToList();
            foreach (var id in personids)
            {
                var person = await _personService.GetPersonByIdAsync(id);
                if (person != null)
                {
                    Persons.Add(person);
                }
            }
            PlayerOptions = Persons
                .Select(p => new SelectListItem
                {
                    Value = p!.Id.ToString(),
                    Text =p.Name
                })
                .ToList();

            Teams = await _teamService.GetAllTeamsAsync();
            TeamOptions = Teams
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                })
                .ToList();
            var existingPerson = await _personService.GetPersonByIdAsync(SelectedPlayerId);
            if (existingPerson == null)
            {
                ModelState.AddModelError(string.Empty, "Selected person not found.");
                return Page();
            }
            NewPerson.Id = existingPerson.Id;
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
            var existingTeamMember = Players.FirstOrDefault(p => p.PersonId == NewPerson.Id);
            if (existingTeamMember == null)
            {
                ModelState.AddModelError(string.Empty, "Team member not found.");
                return Page();
            }
            

            var updatedperson = await _personService.UpdatePersonAsync(NewPerson);

            NewPlayer.Id = existingTeamMember.Id;
            NewPlayer.PersonId = NewPerson.Id;
            NewPlayer.Period = period;
            NewPlayer.Type = type;
            NewPlayer.TeamId = TeamId.Value;

            await _teammemberService.UpdateTeamMemberAsync(NewPlayer);
            return RedirectToPage();

        }
    }
}