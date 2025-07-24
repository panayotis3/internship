using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Models;


namespace internship.Pages
{
    public class DTeamsModel : PageModel
    {
        private readonly ITeamService _teamService;

        public DTeamsModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [BindProperty]
        public List<int> SelectedTeamIds { get; set; } = new();

        public List<Team> Teams { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!SelectedTeamIds.Any())
            {
                ModelState.AddModelError(string.Empty, "Please select at least one team to delete.");
                Teams = await _teamService.GetAllTeamsAsync();
                return Page();
            }

            await _teamService.DeleteTeamAsync(SelectedTeamIds);
            return RedirectToPage();
        }
    }
}
