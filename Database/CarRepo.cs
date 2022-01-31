using System.Net.Http.Headers;
using System.Text.Json;
using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL.Language.AST;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace GQL
{
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
            var c = _context.Cars.FirstOrDefault(c => c.Id == id);
            c.CarModel = _context.CarModels.Where(m => m.Id == c.CarModelId).FirstOrDefault();
            return c;
        }

        public async Task<CarModel> GetCarModelById(long id)
        {
            var cm = _context.CarModels.FirstOrDefault(m => m.Id == id);
            return cm;
        }

        public async Task<Statistics> GetStatisticsAsync()
        {
            var s = new Statistics()
            {
                CountObjects = await _context.Cars.CountAsync(),
                DateFirstEntry = _context.Cars.FirstAsync().Result.LastEditUpdate,
                DateLastEntry = _context.Cars.ToArray().Last().LastEditUpdate,
                FirstCar = _context.Cars.FirstAsync().Result,
                LastCar = _context.Cars.ToArray().Last()
            };
            return s;
        }

        public async Task<ReportT> AddCarAsync(Car json)
        {
            var car = json;
            if (_context.CarModels.Where(m => m.Id == json.CarModelId).FirstOrDefault() != null)
            {
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
            else
            {
                return new ReportT() {Report = "This manufacturer does not exist. Create a CarModel object"};
            }
        }

        public async Task<ReportT> AddCarModelAsync(CarModel json)
        {
            var carmodel = new CarModel()
            {
                Name = json.Name, Id = json.Id, Url = json.Url, LastEditUpdate = DateTime.Now.ToString()
            };
            if (_context.CarModels.Where(c => c == carmodel).FirstOrDefault() != null)
            {
                return new ReportT() {Report = "Error: Object already exists"};
            }
            else
            {
                var cm = _context.CarModels.Add(carmodel).Entity;
                await _context.SaveChangesAsync();
                if (cm != null)
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
            var car = _context.Cars.FirstOrDefault(c => c.Id == Id);
            if (car != null)
            {
                var cc = _context.Cars.Remove(car).Entity;
                _context.Entry(car).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return new ReportT(){Report = "Succes"};
            }
            else
            {
                return new ReportT(){Report = "Error: Object does not exist"};
            }
        }

        public async Task<ReportT> RemoveCarModelByIdAsync(long Id)
        {
            var cm = _context.CarModels.FirstOrDefault(m => m.Id == Id);
            if (cm != null)
            {
                var ccm = _context.CarModels.Remove(cm).Entity;
                _context.Entry(cm).State = EntityState.Deleted;
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