using MatchDataManager.Api.DTO.Locations.Queries;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Repositories;
using MediatR;

namespace MatchDataManager.Api.Infrastructure.Handlers.Locations
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationsQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetAllLocations();
        }
    }
}
