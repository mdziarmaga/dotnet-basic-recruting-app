using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.DTO.Teams.Queries
{
    public class GetTeamByIdQuery : IRequest<Team>
    {
        public Guid Id { get; set; }
    }
}
