using internship.features.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Services;
namespace internship.Pages;

public class TournamentDetailsModel : PageModel
{
    private readonly IFictureService _fictureService;
    private readonly IStadiumService _stadiumService;
    private readonly ITeamService _teamService;
    private readonly ITournamentService _tournamentService;
    private readonly IRefereeService _refereeService;
    private readonly IPersonService _personService;

    public TournamentDetailsModel(IFictureService fictureService, IStadiumService stadiumService, ITeamService teamService, ITournamentService tournamentService, IRefereeService refereeService, IPersonService personService)
    {
        _fictureService = fictureService;
        _stadiumService = stadiumService;
        _teamService = teamService;
        _tournamentService = tournamentService;
        _refereeService = refereeService;
        _personService = personService;
    }

    public Tournament? Tournament { get; set; }
    public List<Ficture> Fictures { get; set; } = new();
    public List<Team> HomeTeams { get; set; } = new();
    public List<Team> AwayTeams { get; set; } = new();
    public List<Stadium> Stadiums { get; set; } = new();
    public List<Referee> Referees { get; set; } = new();
    public List<Person> Refnames { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Tournament = await _tournamentService.GetTournamentByIdAsync(id);
        if (Tournament == null)
        {
            return NotFound();
        }
        var fictures = await _fictureService.GetAllFicturesAsync();
        Fictures = fictures.Where(f => f.TournamentId == id).ToList();
        foreach (var ficture in Fictures)
        {
            var homeTeam = await _teamService.GetTeamByIdAsync(ficture.HomeTeamId);
            if (homeTeam != null)
            {
                HomeTeams.Add(homeTeam);
            }
            var awayTeam = await _teamService.GetTeamByIdAsync(ficture.AwayTeamId);
            if (awayTeam != null)
            {
                AwayTeams.Add(awayTeam);
            }
            var stadium = await _stadiumService.GetStadiumByIdAsync(ficture.StadiumId);
            if (stadium != null)
            {
                Stadiums.Add(stadium);
            }
            var referee = await _refereeService.GetRefereeByIdAsync(ficture.RefereeId);
            if (referee != null)
            {
                Referees.Add(referee);

                var person = await _personService.GetPersonByIdAsync(referee.PersonId);
                if (person != null)
                {
                    Refnames.Add(person);
                }
            }

        }
        return Page();
    }

}