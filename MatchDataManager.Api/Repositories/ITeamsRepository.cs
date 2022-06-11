using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories
{
    public interface ITeamsRepository
    {
        public Task<Team> AddTeam(Team team);
        public Task<bool> DeleteTeam(Guid teamId);
        public Task<IEnumerable<Team>> GetAllTeams();
        public Task<Team> GetTeamById(Guid id);
        public Task<Team> UpdateTeam(Team team);
    }
}
