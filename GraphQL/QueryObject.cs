using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;

namespace GQL.GraphQL;

public class QueryObject : ObjectGraphType<object>
{
    public QueryObject(ICarRepo repo)
    {
        Field<ListGraphType<CarObject>>(
            "GetAllObjectsAsync",
            "Get all cars",
            new QueryArguments(),
            context => repo.GetAllObjects()
            );
        FieldAsync<CarObject, Car>(
            "GetCarById",
            "Get car by id",
            new QueryArguments(
                new QueryArgument<NonNullGraphType<LongGraphType>>
                {
                    Name = "id",
                    Description = ""
                }),
            context => repo.GetCarByIDAsync(context.GetArgument<long>("id"))
            );
        FieldAsync<StatisticsObject, Statistics>(
            "GetStatistics",
            "Get statistics",
            new QueryArguments(),
            context => repo.GetStatisticsAsync()
            );
    }
}