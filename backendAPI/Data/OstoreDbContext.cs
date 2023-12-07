using Microsoft.EntityFrameworkCore;
using System.Drawing;
using backendAPI.Model;

namespace O.thompsonStore.Data
{
    public class AutoPartDbContext : DbContext
    {
        public DbSet<MainForm> info { get; set; }
        public DbSet<Serivce> Service    { get; set; }
        public DbSet<Parts> Parts { get; set; }

        

        public AutoPartDbContext(DbContextOptions<AutoPartDbContext> options) : base(options) { }

    }
}
