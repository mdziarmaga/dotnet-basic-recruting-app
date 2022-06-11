using MatchDataManager.Api.Data;
using MatchDataManager.Api.Helpers;
using MatchDataManager.Api.Infrastructure.Exceptions;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private readonly IMatchContext _matchContext;

    public TeamsRepository(IMatchContext matchContext)
    {
        _matchContext = matchContext;
    }

    public async Task<Team> AddTeam(Team team)
    {
        var teams = _matchContext.Team;
        foreach (var item in teams)
            CheckNameHelper.CheckName(item.Name, team.Name, string.Empty);

        team.Id = Guid.NewGuid();
        _matchContext.Team.Add(team);
        await _matchContext.SaveChanes();

        return team;
    }

    public async Task<bool> DeleteTeam(Guid teamId)
    {
        var team = _matchContext.Team.FirstOrDefault(x => x.Id == teamId) ?? throw new NotFoundException(teamId); ;
        if (team is not null)
        {
            _matchContext.Team.Remove(team);
        }
        await _matchContext.SaveChanes();

        return true;
    }

    public async Task<IEnumerable<Team>> GetAllTeams()
    {
        return _matchContext.Team;
    }

    public async Task<Team> GetTeamById(Guid id)
    {
        return _matchContext.Team.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException(id); ;
    }

    public async Task<Team> UpdateTeam(Team team)
    {
        var teams = _matchContext.Team;
        var existingTeam = teams.FirstOrDefault(x => x.Id == team.Id) ?? throw new NotFoundException(team.Id); ;
        if (existingTeam is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        foreach (var item in teams)
            CheckNameHelper.CheckName(item.Name, team.Name, existingTeam.Name);

        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;
        await _matchContext.SaveChanes();

        return team;
    }
}