using internship.features.core.Models;
using internship.features.core.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Services;
namespace internship.Pages;
public class TeamDetailsModel : PageModel
{
    private readonly ITeamService _teamService;
    private readonly ITeamMemberService _teammemberService;
    private readonly IPersonService _personService;
    private readonly IStadiumService _stadiumService;

    public TeamDetailsModel(ITeamService teamService, ITeamMemberService teamMemberService, IPersonService personService, IStadiumService stadiumService)
    {
        _teamService = teamService;
        _teammemberService = teamMemberService;
        _personService = personService;
        _stadiumService = stadiumService;
    }

    public Team? Team { get; set; }
    public List<TeamMember> Players { get; set; } = new();
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
        return Page();
    }
}
