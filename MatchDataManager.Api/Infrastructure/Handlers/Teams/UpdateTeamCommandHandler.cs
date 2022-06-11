using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Infrastructure.Handlers.Teams
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, Team>
    {
        private readonly ITeamsRepository _teamRepository;

        public UpdateTeamCommandHandler(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            return await _teamRepository.UpdateTeam(request.Team);
        }
    }
}
