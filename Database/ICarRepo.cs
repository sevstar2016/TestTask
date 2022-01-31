using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL.Types;

namespace GQL
{
    public interface ICarRepo
    {
        //Query
        public List<Car> GetAllObjects();
        public Task<Car> GetCarByIDAsync(long id);
        public Task<CarModel> GetCarModelById(long id);
        public Task<Statistics> GetStatisticsAsync();

        //Mutations
        public Task<ReportT> AddCarAsync(Car json);
        public Task<ReportT> AddCarModelAsync(CarModel json);
        public Task<ReportT> RemoveCarByIdAsync(long Id);
        public Task<ReportT> RemoveCarModelByIdAsync(long Id);
    }
}