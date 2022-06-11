using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Infrastructure.Handlers.Teams
{
    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, Team>
    {
        private readonly ITeamsRepository _teamRepository;

        public AddTeamCommandHandler(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            return await _teamRepository.AddTeam(request.Team);
        }
    }
}
