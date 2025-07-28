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

    public TeamDetailsModel(ITeamService teamService, ITeamMemberService teamMemberService, IPersonService personService)
    {
        _teamService = teamService;
        _teammemberService = teamMemberService;
        _personService = personService;
    }

    public Team? Team { get; set; }
    public List<TeamMember> Players { get; set; } = new();
    public List<Person?> Persons { get; set; } = new();
    public List<int> personids { get; set; } = new();


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
        return Page();
    }
}
