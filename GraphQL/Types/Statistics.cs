using GQL.Models;
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
        Field(s => s.FirstCar, type: typeof(CarObject));
        Field(s => s.DateLastEntry);
        Field(s => s.LastCar, type: typeof(CarObject));
    }
}

public class Statistics
{
    public long CountObjects { get; set; }
    public string DateFirstEntry { get; set; }
    public Car FirstCar { get; set; }
    
    public string DateLastEntry { get; set; }
    public Car LastCar { get; set; }
}