using GQL.GraphQL.Types;
using GQL.Models;
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
    }
}