using MatchDataManager.Api.Data;
using MatchDataManager.Api.Helpers;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class LocationsRepository : ILocationRepository
{
    private readonly IMatchContext _matchContext;

    public LocationsRepository(IMatchContext matchContext)
    {
        _matchContext = matchContext;
    }

    public void AddLocation(Location location)
    {
        var locations = _matchContext.Location;
        foreach (var item in locations)
            CheckNameHelper.CheckName(item.Name, location.Name);

        location.Id = Guid.NewGuid();
        _matchContext.Location.Add(location);
        _matchContext.SaveChanes();
    }

    public void DeleteLocation(Guid locationId)
    {
        var location = _matchContext.Location.FirstOrDefault(x => x.Id == locationId);
        if (location is not null)
        {
            _matchContext.Location.Remove(location);
        }
        _matchContext.SaveChanes();
    }

    public IEnumerable<Location> GetAllLocations()
    {
        return _matchContext.Location;
    }

    public Location GetLocationById(Guid id)
    {
        return _matchContext.Location.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateLocation(Location location)
    {
        var locations = _matchContext.Location;
        var existingLocation = locations.FirstOrDefault(x => x.Id == location.Id);
        if (existingLocation is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }

        foreach (var item in locations)
            CheckNameHelper.CheckName(item.Name, location.Name);

        existingLocation.City = location.City;
        existingLocation.Name = location.Name;
        _matchContext.SaveChanes();
    }
}