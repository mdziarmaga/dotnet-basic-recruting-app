using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.Repositories;
using MediatR;

namespace MatchDataManager.Api.Infrastructure.Handlers.Locations
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, bool>
    {
        private readonly ILocationRepository _locationRepository;

        public DeleteLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<bool> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            return await _locationRepository.DeleteLocation(request.Id);
        }
    }
}
