using internship.features.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace internship.features.core.Pages
{
    public class UTeamsModel : PageModel
    {
        private readonly ITeamService _teamService;

        public UTeamsModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [BindProperty]
        public int? TeamId { get; set; }

        [BindProperty]
        public Team NewTeam { get; set; } = new Team { Name = string.Empty, City = string.Empty, Country = string.Empty };

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

            existingTeam.Name = NewTeam.Name;
            existingTeam.City = NewTeam.City;
            existingTeam.Country = NewTeam.Country;

            await _teamService.UpdateTeamAsync(existingTeam);
            return RedirectToPage();
        }
    }
}
