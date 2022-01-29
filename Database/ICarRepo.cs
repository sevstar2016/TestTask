using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL.Types;

namespace GQL
{
    public interface ICarRepo
    {
        public List<Car> GetAllObjects();
        public Task<Car> AddCarAsync(Car json);
        public Task<Car> RemoveCarByIdAsync(long Id);
    }
}