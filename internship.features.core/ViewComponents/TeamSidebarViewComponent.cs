using Microsoft.AspNetCore.Mvc;

public class TeamSidebarViewComponent : ViewComponent
{
    private readonly ITeamService _teamService;

    public TeamSidebarViewComponent(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var teams = await _teamService.GetAllTeamsAsync(); 
        return View(teams);
    }
}
