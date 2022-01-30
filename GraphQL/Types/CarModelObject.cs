using GQL.Models;
using GraphQL.Types;

namespace GQL.GraphQL.Types;

public class CarModelObject : ObjectGraphType<CarModel>
{
    public CarModelObject()
    {
        Name = nameof(CarModel);
        Description = "";

        Field(m => m.Id);
        Field(m => m.Name);
        Field(m => m.Url);
    }
}