using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Models;

namespace internship.Pages
{
    public class LTeamsModel : PageModel
    {
        private readonly ITeamService _teamService;

        public LTeamsModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public List<Team> Teams { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            return Page();
        }
    }
}
