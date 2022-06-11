using MatchDataManager.Api.Data;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Helpers;
using MatchDataManager.Api.Infrastructure.Exceptions;

namespace MatchDataManager.Api.Repositories;

public class LocationsRepository : ILocationRepository
{
    private readonly IMatchContext _matchContext;

    public LocationsRepository(IMatchContext matchContext)
    {
        _matchContext = matchContext;
    }

    public async Task<Location> AddLocation(Location location)
    {
        var locations = _matchContext.Location;
        foreach (var item in locations)
            CheckNameHelper.CheckName(item.Name, location.Name, string.Empty);

        location.Id = Guid.NewGuid();
        _matchContext.Location.Add(location);
        await _matchContext.SaveChanes();

        return location;
    }

    public async Task<bool> DeleteLocation(Guid locationId)
    {
        var location = _matchContext.Location.FirstOrDefault(x => x.Id == locationId) ?? throw new NotFoundException(locationId);
        if (location is not null)
        {
            _matchContext.Location.Remove(location);
        }
        await _matchContext.SaveChanes();

        return true;
    }

    public async Task<IEnumerable<Location>> GetAllLocations()
    {
        return _matchContext.Location;
    }

    public async Task<Location> GetLocationById(Guid id)
    {
        return _matchContext.Location.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException(id); 
    }

    public async Task<Location> UpdateLocation(Location location)
    {
        var locations = _matchContext.Location;
        var existingLocation = locations.FirstOrDefault(x => x.Id == location.Id) ?? throw new NotFoundException(location.Id);
        if (existingLocation is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }

        foreach (var item in locations)
            CheckNameHelper.CheckName(item.Name, location.Name, existingLocation.Name);

        existingLocation.City = location.City;
        existingLocation.Name = location.Name;
        await _matchContext.SaveChanes();

        return location;
    }
}