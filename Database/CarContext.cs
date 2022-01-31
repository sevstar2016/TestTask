using GQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GQL
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            
        }
        
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().ToTable("CarModel");
            modelBuilder.Entity<Car>().ToTable("Car");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db");
        }
    }
}

