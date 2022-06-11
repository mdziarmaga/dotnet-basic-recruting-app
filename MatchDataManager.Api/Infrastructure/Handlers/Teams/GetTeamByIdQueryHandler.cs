using MatchDataManager.Api.DTO.Teams.Queries;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Infrastructure.Handlers.Teams
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Team>
    {
        private readonly ITeamsRepository _teamRepository;

        public GetTeamByIdQueryHandler(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            return await _teamRepository.GetTeamById(request.Id);
        }
    }
}
