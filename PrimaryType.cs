namespace AutoMapper.Extensions.ExpressionMapping.bug_mapped_types;

public class PrimaryType
{
    public MemberType Member { get; set; } = new();

    public DateOnly StringDateOnly { get; set; }
    public DateOnly ObjectDateOnly { get; set; }

    public Date Date { get; set; } = null!;
    public Date DateString { get; set; } = null!;
}
