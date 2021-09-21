using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotDesk.Infrastructure
{
    public class HotDeskDbContextDesignTimeFactory: IDesignTimeDbContextFactory<HotDeskDbContext>
    {
        public HotDeskDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotDeskDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotDesk;Trusted_Connection=True");

            return new HotDeskDbContext(optionsBuilder.Options);
        }
    }
}
