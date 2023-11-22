namespace AutoMapper.Extensions.ExpressionMapping.bug_mapped_types;

public class MemberTypeDto
{
    public string Name { get; set; } = string.Empty;

    public string StringDateOnly { get; set; } = string.Empty;

    public Date ObjectDateOnly { get; set; } = null!;

    public string DateString { get; set; } = null!;
}
