using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Models;

namespace internship.Pages
{
    public class CTeamsModel : PageModel
    {
        private readonly ITeamService _teamService;

        public CTeamsModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [BindProperty]
        public Team NewTeam { get; set; } = new Team { Name = string.Empty, City = string.Empty, Country = string.Empty };

        public List<Team> Teams { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Teams = await _teamService.GetAllTeamsAsync();
                return Page();
            }

            await _teamService.CreateTeamAsync(NewTeam);
            return RedirectToPage(); 
        }
    }
}