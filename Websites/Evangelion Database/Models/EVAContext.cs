using Microsoft.EntityFrameworkCore;

namespace EvangelionDatabase.Models
{
    public class EVAContext : DbContext
    {
        public EVAContext(DbContextOptions<EVAContext> options)
            :base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotEvangelions>().HasKey(e => new {e.EvangelionID, e.PilotID});
        }

        public DbSet<Pilot> Pilot {get; set;} = default!;
        public DbSet<Evangelion> Evangelion {get; set;} = default!;
        public DbSet<PilotEvangelions> PilotEvangelion {get; set;} = default!;
        }
}