using System.Linq.Expressions;
using Shouldly;
using Xunit;

namespace AutoMapper.Extensions.ExpressionMapping.bug_mapped_types;
public class EntityDefectTests
{
    private readonly IMapper mapper = new MapperConfiguration(_ =>
    {
        _.AddExpressionMapping();
        _.CreateMap<MemberType, MemberTypeDto>()
            .ReverseMap();
        _.CreateMap<PrimaryType, PrimaryTypeDto>()
            .ReverseMap();
        _.CreateMap<string, DateOnly>()
            .ConvertUsing((s, _) => DateOnly.Parse(s));
        _.CreateMap<DateOnly, string>()
            .ConvertUsing((dt, _) => dt.ToString("O"));
        _.CreateMap<string, DateOnly>()
            .ConvertUsing((s, _) => DateOnly.Parse(s));
        _.CreateMap<DateOnly, string>()
            .ConvertUsing((dt, _) => dt.ToString("O"));
        _.CreateMap<DateOnly, Date>().ReverseMap();
        _.CreateMap<Date, Date2>().ReverseMap();
        _.CreateMap<Date, string>().ConvertUsing((d, _) => $"{d.Year:0000}-{d.Month:00}-{d.Day:00}");
        _.CreateMap<string, Date>().ConvertUsing((d, _) =>
        {
            var dt = DateOnly.ParseExact(d, "yyyy-MM-dd");
            return new(dt.Year, dt.Month, dt.Day);
        });

    }).CreateMapper();

    [Fact]
    public void Map_Member()
    {
        Expression<Func<PrimaryType, object?>> sourceExpression = _ => _.Member;
        Should.NotThrow(() => mapper.Map<Expression<Func<PrimaryType, object?>>,
            Expression<Func<PrimaryTypeDto, object?>>>(sourceExpression));
    }

    [Fact]
    public void Map_DateOnly_ToString()
    {
        Expression<Func<PrimaryType, object?>> sourceExpression = _ => _.StringDateOnly;
        mapper.Map<Expression<Func<PrimaryType, object?>>,
            Expression<Func<PrimaryTypeDto, object?>>>(sourceExpression);
    }


    [Fact]
    public void Map_String_ToDateOnly()
    {
        Expression<Func<PrimaryTypeDto, object?>> sourceExpression = _ => _.StringDateOnly;
        mapper.Map<Expression<Func<PrimaryTypeDto, object?>>,
            Expression<Func<PrimaryType, object?>>>(sourceExpression);
    }

    [Fact]
    public void Map_DateOnly_ToDate()
    {
        Expression<Func<PrimaryType, object?>> sourceExpression = _ => _.ObjectDateOnly;
        mapper.Map<Expression<Func<PrimaryType, object?>>,
            Expression<Func<PrimaryTypeDto, object?>>>(sourceExpression);
    }

    [Fact]
    public void Map_Date_ToDate2()
    {
        Expression<Func<PrimaryType, object?>> sourceExpression = _ => _.Date;
        mapper.Map<Expression<Func<PrimaryType, object?>>,
            Expression<Func<PrimaryTypeDto, object?>>>(sourceExpression);
    }

    [Fact]
    public void Map_Date_ToString()
    {
        Expression<Func<PrimaryType, object?>> sourceExpression = _ => _.DateString;
        mapper.Map<Expression<Func<PrimaryType, object?>>,
            Expression<Func<PrimaryTypeDto, object?>>>(sourceExpression);
    }

    [Fact]
    public void Map_String_ToDate()
    {
        Expression<Func<PrimaryTypeDto, object?>> sourceExpression = _ => _.DateString;
        mapper.Map<Expression<Func<PrimaryTypeDto, object?>>,
            Expression<Func<PrimaryType, object?>>>(sourceExpression);
    }
}
