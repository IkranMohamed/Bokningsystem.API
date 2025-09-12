using Microsoft.EntityFrameworkCore;
using Bokningsystem.API.Models;

namespace Bokningsystem.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Anvandare> Anvandare { get; set; }
        public DbSet<Tjanst> Tjanster { get; set; }
        public DbSet<Bokning> Bokningar { get; set; }
    }
}
