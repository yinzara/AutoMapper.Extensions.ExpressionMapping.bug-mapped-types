namespace AutoMapper.Extensions.ExpressionMapping.bug_mapped_types;

public class PrimaryTypeDto
{
    public MemberTypeDto Member { get; set; } = new();

    public string StringDateOnly { get; set; } = string.Empty;

    public Date ObjectDateOnly { get; set; } = null!;

    public Date2 Date { get; set; } = null!;

    public string DateString { get; set; } = null!;
}
