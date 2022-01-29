using GraphQL.Types;

namespace GQL.GraphQL;

public class CarSchema : Schema
{
    public CarSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
    {
        Query = query;
        Mutation = mutation;
    }
}