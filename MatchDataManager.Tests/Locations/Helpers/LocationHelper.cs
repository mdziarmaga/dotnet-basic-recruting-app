using MatchDataManager.Api.DTO.Models;

namespace MatchDataManager.Tests.Locations.Helpers
{
    public static class LocationHelper
    {
        public static List<Location> Get()
            => new List<Location>
            {
               new Location { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), City = "city test1", Name ="test name1"},
               new Location { Id = new Guid("77c90127-9424-4fa9-a903-24d62815c9dd"), City = "city test2", Name ="test name2"}
            };
    }
}
