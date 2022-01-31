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

        FieldAsync<ReportObject, ReportT>(
            "AddCarAsync",
            "Add car from JSON",
            new QueryArguments(
                new QueryArgument<NonNullGraphType<CarInputType>>
                {
                    Name = "json",
                    Description = "JSON for add car"
                }
            ),
            context => { return repo.AddCarAsync(context.GetArgument<Car>("json")); }
        );

        FieldAsync<ReportObject, ReportT>(
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

        FieldAsync<ReportObject, ReportT>(
            "AddCarModel",
            "Add car model",
            new QueryArguments(
                new QueryArgument<NonNullGraphType<CarModelInputType>>()
                {
                    Name = "json"
                }
            ),
            context => repo.AddCarModelAsync(context.GetArgument<CarModel>("json"))
        );

        FieldAsync<ReportObject, ReportT>(
            "RemoveCarModel",
            "Renove car model",
            new QueryArguments(
                new QueryArgument<NonNullGraphType<LongGraphType>>()
                {
                    Name = "Id"
                }),
            context => repo.RemoveCarModelByIdAsync(context.GetArgument<long>("Id"))
        );
    }
}