using internship.features.core.Models;
using internship.features.core.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Services;
using internship.features.core.Services.Abstractions;
namespace internship.Pages;
public class TeamDetailsModel : PageModel
{
    private readonly ITeamService _teamService;
    private readonly ITeamMemberService _teammemberService;
    private readonly IPersonService _personService;
    private readonly IStadiumService _stadiumService;
    private readonly IStandingService _standingService;
    private readonly IJunctionTournamentService _junctiontournamentService;
    private readonly ITournamentService _tournamentService;

    public TeamDetailsModel(ITeamService teamService, ITeamMemberService teamMemberService, IPersonService personService, IStadiumService stadiumService, IStandingService standingService, IJunctionTournamentService junctiontournamentService, ITournamentService tournamentService)
    {
        _teamService = teamService;
        _teammemberService = teamMemberService;
        _personService = personService;
        _stadiumService = stadiumService;
        _standingService = standingService;
        _junctiontournamentService = junctiontournamentService;
        _tournamentService = tournamentService;
    }

    public Team? Team { get; set; }
    public List<TeamMember> Players { get; set; } = new();
    public List<JunctionTournament> JunctionTournaments { get; set; } = new();
    public List<int> tournamentids { get; set; } = new();
    public List<int> junctiontournamentids { get; set; } = new();
    public List<Standing?> Standings { get; set; } = new();
    public List<Tournament> Tournaments { get; set; } = new();
    public List<Person?> Persons { get; set; } = new();
    public List<int> personids { get; set; } = new();
    public Stadium? Stadium { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Players = await _teammemberService.GetTeamMembersByTeamIdAsync(id);
        personids = Players.Select(p => p.PersonId).ToList();


        foreach (var ID in personids)
        {
            var person = await _personService.GetPersonByIdAsync(ID);
            if (person != null)
            {
                Persons.Add(person);
            }
        }
        Team = await _teamService.GetTeamByIdAsync(id);
        if (Team == null)
        {
            return NotFound();
        }
        Stadium = await _stadiumService.GetStadiumByTeamIdAsync(id);
        if (Stadium == null)
        {
           return NotFound();
        }
        JunctionTournaments = await _junctiontournamentService.GetJunctionTournamentsByTeamIdAsync(id);
        if (JunctionTournaments == null)
        {
            return NotFound();
        }
        tournamentids = JunctionTournaments.Select(jt => jt.TournamentId).ToList();
        foreach (var ID in tournamentids)
        {
            var tournament = await _tournamentService.GetTournamentByIdAsync(ID);
            if (tournament != null)
            {
                Tournaments.Add(tournament);
            }
        }
        junctiontournamentids = JunctionTournaments.Select(jt => jt.Id).ToList();
        foreach (var ID in junctiontournamentids)
        {
            var standings = await _standingService.GetStandingsByJunctionTournamentIdAsync(ID);
            if (standings != null)
            {
                Standings.AddRange(standings);
            }
        }
        return Page();
    }
}
