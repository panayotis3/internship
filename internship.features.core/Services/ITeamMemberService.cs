using internship.features.core.Models;
namespace internship.features.core.Services;

public interface ITeamMemberService
{
    Task CreateTeamMemberAsync(TeamMember teamMember);
    Task<List<TeamMember>> GetAllTeamMembersAsync();
    Task<List<TeamMember>> GetAllPlayersAsync();
    Task DeleteTeamMemberAsync(List<int> teammemberIds);
    Task UpdateTeamMemberAsync(TeamMember teammember);
    Task<List<TeamMember>> GetTeamMembersByTeamIdAsync(int teamId);
    Task<TeamMember?> GetTeamMemberByIdAsync(int id);
}