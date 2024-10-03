using PeakPerformance.Application.Dtos._Base;
using System.Linq.Expressions;

namespace PeakPerformance.Application.Extensions;

public static partial class Extensions
{
    public static IMappingExpression<TSource, TDestination> ForLookup<TSource, TDestination, TEnum>(
        this IMappingExpression<TSource, TDestination> source,
        Expression<Func<TDestination, LookupValueDto>> lookupExpression,
        Func<TSource, TEnum?> sourceMappingExpression
      )
    where TEnum : struct, Enum
        => source.ForMember(lookupExpression, opt => opt.MapFrom((src, dest, prop, ctx) => sourceMappingExpression(src).ToLookupValueDto()));

    public static IMappingExpression<TSource, TDestination> ForLookup<TSource, TDestination, TEnum>(
        this IMappingExpression<TSource, TDestination> source,
        Expression<Func<TDestination, LookupValueDto>> lookupExpression,
        Func<TSource, TEnum> sourceMappingExpression
      )
    where TEnum : struct, Enum
        => source.ForMember(lookupExpression, opt => opt.MapFrom((src, dest, prop, ctx) => sourceMappingExpression(src).ToLookupValueDto()));
}