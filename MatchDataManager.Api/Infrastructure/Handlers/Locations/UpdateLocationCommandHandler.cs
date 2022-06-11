using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Repositories;
using MediatR;

namespace MatchDataManager.Api.Infrastructure.Handlers.Locations
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Location>
    {
        private readonly ILocationRepository _locationRepository;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            return await _locationRepository.UpdateLocation(request.Location);
        }
    }
}
