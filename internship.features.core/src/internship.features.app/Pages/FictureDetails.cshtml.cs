using internship.features.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using internship.features.core.Models;
using internship.features.core.Services.Abstractions;

namespace internship.features.core.Pages
{
    public class FictureDetailsModel : PageModel
    {
        private readonly IFictureService _fictureService;
        private readonly IStadiumService _stadiumService;
        private readonly ITeamService _teamService;
        private readonly ITournamentService _tournamentService;
        private readonly IRefereeService _refereeService;
        private readonly IPersonService _personService;
        private readonly IGoalService _goalService;
        private readonly ICardService _cardService;
        private readonly ITeamMemberService _teammemberService;
        public FictureDetailsModel(IFictureService fictureService, IStadiumService stadiumService, ITeamService teamService, ITournamentService tournamentService, IRefereeService refereeService, IPersonService personService, ICardService cardService, IGoalService goalService, ITeamMemberService teammemberService)
        {
            _fictureService = fictureService;
            _stadiumService = stadiumService;
            _teamService = teamService;
            _tournamentService = tournamentService;
            _refereeService = refereeService;
            _personService = personService;
            _cardService = cardService;
            _goalService = goalService;
            _teammemberService = teammemberService;
        }
        public Ficture? Ficture { get; set; }
        public List<Goal> Goals { get; set; } = new();
        public List<Card> Cards { get; set; } = new();
        public List<Goal> HomeTeamGoals { get; set; } = new();
        public List<Goal> AwayTeamGoals { get; set; } = new();
        public List<TeamMember?> HomeScorers { get; set; } = new();
        public List<TeamMember?> AwayScorers { get; set; } = new();
        public List<Person?> HomeTeamScorers { get; set; } = new();
        public List<Person?> AwayTeamScorers { get; set; } = new();
        public List<Person?> HomeCardedPlayers { get; set; } = new();
        public List<TeamMember?> CardedPlayers { get; set; } = new();
        public List<Person?> AwayCardedPlayers { get; set; } = new();
        public Referee? FictureReferee { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public Stadium? FictureStadium { get; set; }
        public Tournament? FictureTournament { get; set; }
        public Person? RefereePerson { get; set; }

        public async Task OnGet(int id)
        {
            Ficture = await _fictureService.GetFictureByIdAsync(id);
            if (Ficture != null)
            {
                HomeTeam = await _teamService.GetTeamByIdAsync(Ficture.HomeTeamId);
                AwayTeam = await _teamService.GetTeamByIdAsync(Ficture.AwayTeamId);
                FictureStadium = await _stadiumService.GetStadiumByIdAsync(Ficture.StadiumId);
                FictureTournament = await _tournamentService.GetTournamentByIdAsync(Ficture.TournamentId);

                //Referee Method:
                FictureReferee = await _refereeService.GetRefereeByIdAsync(Ficture.RefereeId);
                if (FictureReferee != null)
                {
                    RefereePerson = await _personService.GetPersonByIdAsync(FictureReferee.PersonId);
                }

                //Goal Method:
                Goals = await _goalService.GetGoalsByFictureIdAsync(id);
                HomeTeamGoals = Goals.Where(g => g.ScoringTeamId == Ficture.HomeTeamId).ToList();
                
                foreach (var goal in HomeTeamGoals)
                {
                    var scorer = await _teammemberService.GetTeamMemberByIdAsync(goal.TeamMemberId);
                    if (scorer != null)
                    {
                        HomeScorers.Add(scorer);
                    }
                }
                foreach (var teammember in HomeScorers)
                {
                    if (teammember == null) continue;
                    var persons = await _personService.GetPersonByIdAsync(teammember.PersonId);
                    if (persons != null)
                    {
                        HomeTeamScorers.Add(persons);
                    }
                }

                AwayTeamGoals = Goals.Where(g => g.ScoringTeamId == Ficture.AwayTeamId).ToList();

                foreach (var goal in AwayTeamGoals)
                {
                    var scorer = await _teammemberService.GetTeamMemberByIdAsync(goal.TeamMemberId);
                    if (scorer != null)
                    {
                        AwayScorers.Add(scorer);
                    }
                }
                foreach (var teammember in AwayScorers)
                {
                    if (teammember == null) continue;
                    var persons = await _personService.GetPersonByIdAsync(teammember.PersonId);
                    if (persons != null)
                    {
                        AwayTeamScorers.Add(persons);
                    }
                }

                //Card Method:
                Cards = await _cardService.GetCardsByFictureIdAsync(id);
                foreach (var card in Cards)
                {
                    var cardedPlayer = await _teammemberService.GetTeamMemberByIdAsync(card.TeamMemberId);
                    if (cardedPlayer != null)
                    {
                        CardedPlayers.Add(cardedPlayer);
                    }
                }
                foreach (var teammember in CardedPlayers)
                {
                    if (teammember == null) continue;
                    var persons = await _personService.GetPersonByIdAsync(teammember.PersonId);
                    if (persons != null)
                    {
                        if (teammember.TeamId == Ficture.HomeTeamId)
                        {
                            HomeCardedPlayers.Add(persons);
                        }
                        else if (teammember.TeamId == Ficture.AwayTeamId)
                        {
                            AwayCardedPlayers.Add(persons);
                        }
                    }
                }
            }
        }
    }
}
