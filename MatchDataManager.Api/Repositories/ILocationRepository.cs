using MatchDataManager.Api.DTO.Models;

namespace MatchDataManager.Api.Repositories
{
    public interface ILocationRepository
    {
        public Task<Location> AddLocation(Location location);
        public Task<bool> DeleteLocation(Guid locationId);
        public Task<IEnumerable<Location>> GetAllLocations();
        public Task<Location> GetLocationById(Guid id);
        public Task<Location> UpdateLocation(Location location);
    }
}
