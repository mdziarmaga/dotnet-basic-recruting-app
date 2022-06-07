using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Data
{
    public interface IMatchContext
    {
        public DbSet<Location> Location { get; set; }
        public DbSet<Team> Team { get; set; }
        public void SaveChanes();
    }
}
