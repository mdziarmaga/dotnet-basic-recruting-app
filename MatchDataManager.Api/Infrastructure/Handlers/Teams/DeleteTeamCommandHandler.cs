using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Infrastructure.Handlers.Teams
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly ITeamsRepository _teamRepository;

        public DeleteTeamCommandHandler(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            return await _teamRepository.DeleteTeam(request.Id);
        }
    }
}
