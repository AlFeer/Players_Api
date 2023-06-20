using Microsoft.EntityFrameworkCore;
using YoungWolves.Models;

namespace YoungWolves.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Warrior> Warriors { get; set; }
        public DbSet<Club> Clubs { get; set; }
    }
}
