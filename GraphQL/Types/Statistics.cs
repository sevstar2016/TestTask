using GraphQL.Types;

namespace GQL.GraphQL.Types;

public class StatisticsObject : ObjectGraphType<Statistics>
{
    public StatisticsObject()
    {
        Name = nameof(Statistics);
        Description = "";

        Field(s => s.CountObjects);
        Field(s => s.DateFirstEntry);
        Field(s => s.DateLastEntry);
    }
}

public class Statistics
{
    public long CountObjects { get; set; }
    public string DateFirstEntry { get; set; }
    public string DateLastEntry { get; set; }
}