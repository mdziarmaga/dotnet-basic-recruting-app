using MatchDataManager.Api.DTO.Locations.Queries;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Repositories;
using MediatR;

namespace MatchDataManager.Api.Infrastructure.Handlers.Locations
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Location>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetLocationById(request.Id);
        }
    }
}
