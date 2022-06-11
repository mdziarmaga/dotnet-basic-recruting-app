using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Data
{
    public class MatchContext : DbContext, IMatchContext
    {
        public MatchContext(DbContextOptions<MatchContext> options) : base(options)
        {

        }

        public DbSet<Location> Location { get; set; }
        public DbSet<Team> Team { get; set; }

        public async Task SaveChanes()
        {
            await base.SaveChangesAsync();
        }
    }
}
