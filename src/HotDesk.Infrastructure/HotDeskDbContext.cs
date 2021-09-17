using HotDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace HotDesk.Infrastructure
{
    public class HotDeskDbContext : DbContext
    {
        /// <summary>
        /// Initialises a default instance of <see cref="HotDeskDbContext"/>.
        /// </summary>
        /// <remarks>Required for Entity Framework CLI in order to generate Ef migrations etc.</remarks>
        public HotDeskDbContext()
        {
        }

        public HotDeskDbContext(DbContextOptions<HotDeskDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotDeskDbContext).Assembly);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetProperties().Where(x => x.IsPrimaryKey()))
                {
                    prop.ValueGenerated = ValueGenerated.Never;
                }
            }
        }
    }
}
