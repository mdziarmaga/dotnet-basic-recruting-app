using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories
{
    public interface ITeamsRepository
    {
        public void AddTeam(Team team);
        public void DeleteTeam(Guid teamId);
        public IEnumerable<Team> GetAllTeams();
        public Team GetTeamById(Guid id);
        public void UpdateTeam(Team team);
    }
}
