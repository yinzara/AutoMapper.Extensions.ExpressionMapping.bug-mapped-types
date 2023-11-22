namespace AutoMapper.Extensions.ExpressionMapping.bug_mapped_types;

public class MemberType
{
    public string Name { get; set; } = string.Empty;

    public DateOnly StringDateOnly { get; set; }
    public DateOnly ObjectDateOnly { get; set; }
}
