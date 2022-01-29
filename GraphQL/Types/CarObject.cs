using GQL.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GQL.GraphQL.Types;

public class CarObject : ObjectGraphType<Car>
{
    public CarObject()
    {
        Name = nameof(Car);
        Description = "";

        Field(c => c.Id).Description("Id of car");
        Field(c => c.Color).Description("Color");
        Field(c => c.Name).Description("Name");
        Field(c => c.Url).Description("Url from car");
        Field(c => c.YearOfIssue).Description("Year of issue");
        Field(c => c.CarModelId).Description("Id of car model");
    }
}

public class CarListObject : ObjectGraphType<CarList>
{
    public CarListObject()
    {
        Field<ListGraphType<CarObject>>("cars");
    }
}

public class CarInputType : InputObjectGraphType
{
    public CarInputType()
    {
        Name = "CarInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("color");
        Field<NonNullGraphType<StringGraphType>>("url");
        Field<NonNullGraphType<StringGraphType>>("yearOfIssue");
        Field<NonNullGraphType<LongGraphType>>("carModelId");
    }
}