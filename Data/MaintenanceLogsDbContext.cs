using Microsoft.EntityFrameworkCore;
using MyDashboardApp.Models;
namespace MyDashboardApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        // added to load the log table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //map it
            modelBuilder.Entity<Item>().ToTable("log");
        }
    }
}
