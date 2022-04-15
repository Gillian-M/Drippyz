using Drippyz.Models;
using Microsoft.EntityFrameworkCore;

namespace Drippyz.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }




    }
}
