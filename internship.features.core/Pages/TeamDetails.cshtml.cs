using internship.features.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace internship.Pages;
public class TeamDetailsModel : PageModel
{
    private readonly ITeamService _teamService;

    public TeamDetailsModel(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public Team? Team { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Team = await _teamService.GetTeamByIdAsync(id);
        if (Team == null)
        {
            return NotFound();
        }
        return Page();
    }
}
