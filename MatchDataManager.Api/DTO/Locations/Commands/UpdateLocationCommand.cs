using MatchDataManager.Api.DTO.Models;

namespace MatchDataManager.Api.DTO.Locations.Commands
{
    public class UpdateLocationCommand : IRequest<Location>
    {
        public Location Location { get; set; }
    }
}
