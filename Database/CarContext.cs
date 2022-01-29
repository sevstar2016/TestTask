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
            // modelBuilder.Entity<CarModel>().HasData(
            //     new CarModel
            //     {
            //         Name = "Lamborghini",
            //         Url = "https://www.lamborghini.com/ru-en",
            //     },
            //     new CarModel
            //     {
            //         Name = "Shkoda",
            //         Url = "https://cars.skoda-avto.ru"
            //     });
            // modelBuilder.Entity<Car>().HasData(
            //     new Car
            //     {
            //         Name = "Lamborghini Urus",
            //         Url = "https://www.lamborghini.com/ru-en/модели/urus",
            //         Color = "Yallow",
            //         YearOfIssue = "2017",
            //         CarModelId = 0
            //     },
            //     new Car
            //     {
            //         Name = "Lamborghini aventador S",
            //         Url = "https://www.lamborghini.com/ru-en/история/aventador-s",
            //         YearOfIssue = "2011",
            //         Color = "Yallow",
            //         CarModelId = 0
            //     },
            //     new Car
            //     {
            //         Name = "Shkoda rapid",
            //         Url = "https://cars.skoda-avto.ru/detail/f43193a8-4821-4ebd-9922-b7937cc592bc",
            //         Color = "White",
            //         YearOfIssue = "2022",
            //         CarModelId = 1
            //     });


            modelBuilder.Entity<CarModel>().ToTable("CarModel");
            modelBuilder.Entity<Car>().ToTable("Car");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db");
        }
    }
}

