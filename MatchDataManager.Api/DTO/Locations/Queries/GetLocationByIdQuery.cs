using MatchDataManager.Api.DTO.Models;

namespace MatchDataManager.Api.DTO.Locations.Queries
{
    public class GetLocationByIdQuery : IRequest<Location>
    {
        public Guid Id { get; set; }
    }
}
