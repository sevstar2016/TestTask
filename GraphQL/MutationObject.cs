using GQL.GraphQL.Types;
using GQL.Models;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Newtonsoft.Json.Linq;

namespace GQL.GraphQL;

public class MutationObject : ObjectGraphType<object>
{
    public MutationObject(ICarRepo repo)
    {
        Name = "Mutations";
        Description = "";

        FieldAsync<CarObject, Car>(
            "AddCarAsync",
            "Add car from JSON",
            new QueryArguments(
                new QueryArgument<NonNullGraphType<CarInputType>>
                {
                    Name = "json",
                    Description = "JSON for add car",
                    DefaultValue = new Car
                    {
                        Name = "TestCar",
                        Color="White",
                        YearOfIssue="2011",
                        Url="test.com",
                        CarModelId= 0
                    }
                }
            ),
            context => { return repo.AddCarAsync(context.GetArgument<Car>("json")); }
        );

        FieldAsync<CarObject, Car>(
            "RemoveCarByIdAsync",
            "Remove car by ID",
            new QueryArguments(
                new QueryArgument<NonNullGraphType<LongGraphType>>
                {
                    Name = "Id"
                }
            ),
            context => repo.RemoveCarByIdAsync(context.GetArgument<long>("Id"))
        );
    }
}