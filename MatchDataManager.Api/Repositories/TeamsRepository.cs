using MatchDataManager.Api.Data;
using MatchDataManager.Api.Helpers;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private readonly IMatchContext _matchContext;

    public TeamsRepository(IMatchContext matchContext)
    {
        _matchContext = matchContext;
    }

    public void AddTeam(Team team)
    {
        var teams = _matchContext.Team;
        foreach (var item in teams)
            CheckNameHelper.CheckName(item.Name, team.Name);

        team.Id = Guid.NewGuid();
        _matchContext.Team.Add(team);
        _matchContext.SaveChanes();
    }

    public void DeleteTeam(Guid teamId)
    {
        var team = _matchContext.Team.FirstOrDefault(x => x.Id == teamId);
        if (team is not null)
        {
            _matchContext.Team.Remove(team);
        }
        _matchContext.SaveChanes();
    }

    public IEnumerable<Team> GetAllTeams()
    {
        return _matchContext.Team;
    }

    public Team GetTeamById(Guid id)
    {
        return _matchContext.Team.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateTeam(Team team)
    {
        var teams = _matchContext.Team;
        var existingTeam = teams.FirstOrDefault(x => x.Id == team.Id);
        if (existingTeam is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        foreach (var item in teams)
            CheckNameHelper.CheckName(item.Name, team.Name);

        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;
        _matchContext.SaveChanes();
    }
}