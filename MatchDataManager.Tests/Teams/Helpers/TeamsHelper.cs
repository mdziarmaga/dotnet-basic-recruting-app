using MatchDataManager.Api.Models;

namespace MatchDataManager.Tests.Teams.Helpers
{
    public class TeamsHelper
    {
        public static List<Team> Get()
            => new List<Team>
            {
                new Team { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), CoachName = "coach name test1", Name ="test name1"},
                new Team { Id = new Guid("77c90127-9424-4fa9-a903-24d62815c9dd"), CoachName = "coach name test2", Name ="test name2"}
            };
    }
}