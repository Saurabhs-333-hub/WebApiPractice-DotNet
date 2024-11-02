using Microsoft.EntityFrameworkCore;
using WebApi_.Models.Domains;

namespace WebApi_.Data
{
    public class Web_DbContext:DbContext
    {
        public Web_DbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
