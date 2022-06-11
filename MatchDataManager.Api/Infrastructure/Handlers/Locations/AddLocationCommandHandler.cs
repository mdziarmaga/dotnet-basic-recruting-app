using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Infrastructure.Handlers.Locations
{
    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, Location>
    {
        private readonly ILocationRepository _locationRepository;

        public AddLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            return await _locationRepository.AddLocation(request.Location);
        }
    }
}
