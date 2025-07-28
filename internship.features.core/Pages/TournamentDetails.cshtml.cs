using internship.features.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Services;
namespace internship.Pages;

public class TournamentDetailsModel : PageModel
{
    private readonly ITournamentService _tournamentService;

    public TournamentDetailsModel(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    public Tournament? Tournament { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Tournament = await _tournamentService.GetTournamentByIdAsync(id);
        if (Tournament == null)
        {
            return NotFound();
        }
        return Page();
    }
}