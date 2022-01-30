using GraphQL.Types;

namespace GQL.GraphQL.Types;

public class ReportObject : ObjectGraphType<ReportT>
{
    public ReportObject()
    {
        Name = nameof(ReportT);
        Description = "Report";

        Field(r => r.Report);
    }
}

public class ReportT
{
    public string Report { get; set; }
}