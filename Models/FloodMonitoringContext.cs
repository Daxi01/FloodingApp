using Microsoft.EntityFrameworkCore;

namespace FloodingApp.Models
{
    public class FloodMonitoringContext : DbContext
    {
        public FloodMonitoringContext(DbContextOptions<FloodMonitoringContext> options)
            : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Value> Values { get; set; }
    }
}
