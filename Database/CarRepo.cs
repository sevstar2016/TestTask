using System.Net.Http.Headers;
using System.Text.Json;
using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GQL
{
    public class CarJ
    {
        public string Name;
        public string Color;
        public string YearOfIssue;
        public string Url;
        public string ModelName;
    }
    
    public class CarRepo : ICarRepo
    {
        private readonly CarContext _context;

        public CarRepo(CarContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        
        public List<Car> GetAllObjects()
        {
            return _context.Cars.ToList();
        }

        public async Task<Car> AddCarAsync(Car json)
        {
            Console.WriteLine(json.Name);
            var car = json;
            Console.WriteLine(car);
            var c = _context.Cars.Add(new Car
            {
                Name = car.Name, Color = car.Color, Url = car.Url, YearOfIssue = car.YearOfIssue,
                CarModelId = car.CarModelId
            }).Entity;
            await _context.SaveChangesAsync();

            return c;
        }

        public async Task<Car> RemoveCarByIdAsync(long Id)
        {
            var car = _context.Cars.Remove(_context.Cars.FirstOrDefault(c => c.Id == Id)).Entity;
            await _context.SaveChangesAsync();
            return car;
        }
    }
}