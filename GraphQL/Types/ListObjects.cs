using GQL.Models;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace GQL.GraphQL.Types;

public class CarInputType : InputObjectGraphType<Car>
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