using internship.features.core.Models.ViewModels;
using internship.features.core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

public class TeamSidebarViewComponent : ViewComponent
{
    private readonly ITeamService _teamService;
    private readonly ITournamentService _tournamentService;

    public TeamSidebarViewComponent(ITeamService teamService, ITournamentService tournamentService)
    {
        _teamService = teamService;
        _tournamentService = tournamentService;
    }


    public async Task<IViewComponentResult> InvokeAsync()
    {
        var teams = await _teamService.GetAllTeamsAsync();
        var tournaments = await _tournamentService.GetAllTournamentsAsync();

        var viewModel = new SidebarViewModel
        {
            Teams = teams,
            Tournaments = tournaments
        };

        return View(viewModel);
    }
}
