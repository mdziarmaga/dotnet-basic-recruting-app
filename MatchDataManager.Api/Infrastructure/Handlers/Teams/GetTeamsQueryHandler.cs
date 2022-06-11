using MatchDataManager.Api.DTO.Teams.Queries;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Infrastructure.Handlers.Teams
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IEnumerable<Team>>
    {
        private readonly ITeamsRepository _teamRepository;

        public GetTeamsQueryHandler(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            return await _teamRepository.GetAllTeams();
        }
    }
}
