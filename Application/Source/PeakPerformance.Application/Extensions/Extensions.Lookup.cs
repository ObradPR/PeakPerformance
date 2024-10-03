using PeakPerformance.Application.Dtos._Base;

namespace PeakPerformance.Application.Extensions;

public static partial class Extensions
{
    public static LookupValueDto ToLookupValueDto<T>(this T? value, Func<T, LookupValueDto> transformation = null)
       where T : struct, Enum
    {
        if (value == null)
            return null;

        transformation ??= (T value) => new LookupValueDto
        {
            Id = Convert.ToInt32(value),
            Name = value.ToString(),
            Description = value.GetDescription(),
        };

        return transformation(value.Value);
    }

    public static LookupValueDto ToLookupValueDto<T>(this T value, Func<T, LookupValueDto> transformation = null)
        where T : struct, Enum
    {
        transformation ??= (T value) => new LookupValueDto
        {
            Id = Convert.ToInt32(value),
            Name = value.ToString(),
            Description = value.GetDescription(),
        };

        return transformation(value);
    }

    public static List<LookupValueDto> EnumsToLookupValueDto<T>(Func<T, LookupValueDto> transformation = null)
        where T : struct, Enum
    {
        var values = Common.Extensions.Extensions.GetEnums<T>();

        return values
            .Select(_ => ToLookupValueDto(_, transformation))
            .OrderBy(_ => _.Id)
            .ToList();
    }
}