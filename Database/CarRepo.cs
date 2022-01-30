using System.Net.Http.Headers;
using System.Text.Json;
using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<Car> GetCarByIDAsync(long id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Statistics> GetStatisticsAsync()
        {
            var s = new Statistics()
            {
                CountObjects = await _context.Cars.CountAsync(),
                DateFirstEntry = _context.Cars.FirstAsync().Result.LastEditUpdate,
                DateLastEntry = _context.Cars.ToArray().Last().LastEditUpdate
            };
            return s;
        }

        public async Task<ReportT> AddCarAsync(Car json)
        {
            var car = json;
            var c = new Car
            {
                Name = car.Name, Color = car.Color, Url = car.Url, YearOfIssue = car.YearOfIssue,
                CarModelId = car.CarModelId, LastEditUpdate = DateTime.Now.ToString()
            };
            if (_context.Cars.Where(w => w == c).FirstOrDefault() != null)
            {
                return new ReportT() {Report = "Error: Object already exists"};
            }
            else
            {
                var cc = _context.Cars.Add(c).Entity;
                await _context.SaveChangesAsync();
                if (cc != null)
                {
                    return new ReportT() {Report = "Succeful"};
                }
                else
                {
                    return new ReportT() {Report = "Error: Object could not be created. See logs for details"};
                }
            }
        }

        public async Task<ReportT> RemoveCarByIdAsync(long Id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == Id);
            var cc = new Car();
            if (car != null)
            {
                cc = _context.Cars.Remove(car).Entity;
                _context.Entry(car).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return new ReportT(){Report = "Succes"};
            }
            else
            {
                return new ReportT(){Report = "Error: Object does not exist"};
            }
        }
    }
}