using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace PeakPerformance.Application.Extensions;

public static partial class Extensions
{
    // Image

    public static IRuleBuilderOptions<T, IFormFile> IsValidImage<T>(this IRuleBuilder<T, IFormFile> ruleBuilder, Func<T, bool> condition = null)
    {
        return ruleBuilder.Must(file =>
        {
            if (file is null) return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            return Constants.IMAGE_ALLOWED_EXTENSIONS.Contains(extension);
        })
        .WithMessageAuto(ResourceValidation.File_Allowed_Extensions, Constants.IMAGE_ALLOWED_EXTENSIONS.Join(", "))
        .When(_ => condition?.Invoke(_) ?? true);
    }

    // File

    public static IRuleBuilderOptions<T, IFormFile> IsReasonableSize<T>(this IRuleBuilder<T, IFormFile> ruleBuilder, long maxSizeInMB, Func<T, bool> condition = null)
    {
        return ruleBuilder.Must(file => file != null && file.Length <= maxSizeInMB)
            .WithMessageAuto(ResourceValidation.File_Maximum_Size, maxSizeInMB.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    // Date

    public static IRuleBuilderOptions<T, DateTime> InValidRangeOfDate<T>(
        this IRuleBuilderOptions<T, DateTime> ruleBuilder,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        Func<T, bool> condition = null,
        string resourceValidation = null)
    {
        var message = ResourceValidation.Date_Invalid;
        var args = Array.Empty<string>();

        // Perform argument and message calculation here, based on the provided from/to dates
        if (fromDate.HasValue && toDate.HasValue)
        {
            message = ResourceValidation.Date_InBetween;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG), toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (fromDate.HasValue)
        {
            message = ResourceValidation.Date_After;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (toDate.HasValue)
        {
            message = ResourceValidation.Date_Before;
            args = [toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }

        // Pass calculated args to WithMessageAuto before running the validation
        return ruleBuilder.Must((command, date) =>
        {
            if (fromDate.HasValue && toDate.HasValue)
            {
                return date.IsBetween(fromDate.Value, toDate.Value);
            }
            else if (fromDate.HasValue)
            {
                return date.IsLaterThan(toDate.Value);
            }
            else if (toDate.HasValue)
            {
                return date.IsEarlierThan(toDate.Value);
            }

            return false;
        })
        .WithMessageAuto((resourceValidation ?? message), args)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, DateTime> InValidRangeOfDate<T>(
        this IRuleBuilderOptions<T, DateTime> ruleBuilder,
        Func<T, DateTime?> fromDateFunc = null,
        Func<T, DateTime?> toDateFunc = null,
        Func<T, bool> condition = null,
        string resourceValidation = null)
    {
        var message = ResourceValidation.Date_Invalid;
        var args = Array.Empty<string>();

        T command = default;

        ruleBuilder.When(cmd =>
        {
            command = cmd;
            return true;
        });

        var fromDate = fromDateFunc?.Invoke(command);
        var toDate = toDateFunc?.Invoke(command);

        if (fromDate.HasValue && toDate.HasValue)
        {
            message = ResourceValidation.Date_InBetween;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG), toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (fromDate.HasValue)
        {
            message = ResourceValidation.Date_After;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (toDate.HasValue)
        {
            message = ResourceValidation.Date_Before;
            args = [toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }

        return ruleBuilder.Must((command, date) =>
        {
            if (fromDate.HasValue && toDate.HasValue)
            {
                return date.IsBetween(fromDate.Value, toDate.Value);
            }
            else if (fromDate.HasValue)
            {
                return date.IsLaterThan(fromDate.Value);
            }
            else if (toDate.HasValue)
            {
                return date.IsEarlierThan(toDate.Value);
            }

            return false;
        })
        .WithMessageAuto((resourceValidation ?? message), args)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, DateTime?> InValidRangeOfDate<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        Func<T, bool> condition = null,
        string resourceValidation = null)
    {
        var message = ResourceValidation.Date_Invalid;
        var args = Array.Empty<string>();

        // Perform argument and message calculation here, based on the provided from/to dates
        if (fromDate.HasValue && toDate.HasValue)
        {
            message = ResourceValidation.Date_InBetween;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG), toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (fromDate.HasValue)
        {
            message = ResourceValidation.Date_After;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (toDate.HasValue)
        {
            message = ResourceValidation.Date_Before;
            args = [toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }

        return ruleBuilder.Must((command, date) =>
        {
            if (!date.HasValue)
                return true; // If the date is null, validation passes.

            if (fromDate.HasValue && toDate.HasValue)
            {
                return date.Value.IsBetween(fromDate.Value, toDate.Value);
            }
            else if (fromDate.HasValue)
            {
                return date.Value.IsLaterThan(fromDate.Value);
            }
            else if (toDate.HasValue)
            {
                return date.Value.IsEarlierThan(toDate.Value);
            }

            return false;
        })
        .WithMessageAuto((resourceValidation ?? message), args)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, DateTime?> InValidRangeOfDate<T>(
        this IRuleBuilder<T, DateTime?> ruleBuilder,
        Func<T, DateTime?> fromDateFunc = null,
        Func<T, DateTime?> toDateFunc = null,
        Func<T, bool> condition = null,
        string resourceValidation = null)
    {
        var message = ResourceValidation.Date_Invalid;
        var args = Array.Empty<string>();

        T command = default;

        ruleBuilder.Must(_ => true).When(cmd =>
        {
            command = cmd;
            return true;
        });

        var fromDate = fromDateFunc?.Invoke(command);
        var toDate = toDateFunc?.Invoke(command);

        if (fromDate.HasValue && toDate.HasValue)
        {
            message = ResourceValidation.Date_InBetween;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG), toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (fromDate.HasValue)
        {
            message = ResourceValidation.Date_After;
            args = [fromDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }
        else if (toDate.HasValue)
        {
            message = ResourceValidation.Date_Before;
            args = [toDate.Value.ToString(Constants.DATE_FORMAT_LONG)];
        }

        return ruleBuilder.Must((command, date) =>
        {
            if (!date.HasValue)
                return true; // If the date is null, validation passes.

            if (fromDate.HasValue && toDate.HasValue)
            {
                return date.Value.IsBetween(fromDate.Value, toDate.Value);
            }
            else if (fromDate.HasValue)
            {
                return date.Value.IsLaterThan(fromDate.Value);
            }
            else if (toDate.HasValue)
            {
                return date.Value.IsEarlierThan(toDate.Value);
            }

            return false;
        })
        .WithMessageAuto((resourceValidation ?? message), args)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    // Social Media

    public static IRuleBuilderOptions<T, string> ValidSocialMediaLink<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        Func<T, eSocialMediaPlatform> platformFunc,
        Func<T, bool> condition = null)
    {
        var platform = eSocialMediaPlatform.NotSet;

        return ruleBuilder.Must((command, link) =>
        {
            platform = platformFunc.Invoke(command);

            var platformDescription = platform.GetDescription();

            if (string.IsNullOrWhiteSpace(platformDescription))
                return false;

            return link.StartsWith("https://") && link.Contains(platformDescription, StringComparison.OrdinalIgnoreCase);
        })
        .WithMessageAuto(ResourceValidation.Invalid_Social_Media_Link, platform.GetDescription())
        .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TProperty> IsUrlBasedPlatform<T, TProperty>(
       this IRuleBuilder<T, TProperty> ruleBuilder,
       Func<T, eSocialMediaPlatform> platformFunc,
       Func<T, bool> condition = null)
    {
        var platform = eSocialMediaPlatform.NotSet;

        return ruleBuilder.Must((command, property) =>
        {
            platform = platformFunc.Invoke(command);

            return platform != eSocialMediaPlatform.WhatsApp && platform != eSocialMediaPlatform.Telegram;
        })
        .WithMessageAuto(ResourceValidation.Is_Url_Based_Platform)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TProperty> IsPhoneBasedPlatform<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        Func<T, eSocialMediaPlatform> platformFunc,
        Func<T, bool> condition = null)
    {
        var platform = eSocialMediaPlatform.NotSet;

        return ruleBuilder.Must((command, property) =>
        {
            platform = platformFunc.Invoke(command);

            return platform == eSocialMediaPlatform.WhatsApp || platform == eSocialMediaPlatform.Telegram;
        })
        .WithMessageAuto(ResourceValidation.Is_Phone_Based_Platform)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    //
    // Base
    //

    public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        => ruleBuilder.NotEmpty().WithMessageAuto(ResourceValidation.Required);

    public static IRuleBuilderOptions<T, string> MaximumLengthAuto<T>(this IRuleBuilder<T, string> ruleBuilder, int value, Func<T, bool> condition = null)
    {
        return ruleBuilder
            .MaximumLength(value)
            .WithMessageAuto(ResourceValidation.Maximum_Characters, value.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, string> MinimumLengthAuto<T>(this IRuleBuilder<T, string> ruleBuilder, int value, Func<T, bool> condition = null)
    {
        return ruleBuilder
            .MinimumLength(value)
            .WithMessageAuto(ResourceValidation.Minimum_Characters, value.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TValue> GreaterThanAuto<T, TValue>(this IRuleBuilder<T, TValue> ruleBuilder, TValue value, Func<T, bool> condition = null)
        where TValue : struct, IComparable<TValue>
    {
        if (!Common.Extensions.Extensions.IsNumericType(typeof(TValue)))
        {
            throw new InvalidOperationException(ResourceValidation.Not_Numeric_Type.AppendArgument(typeof(TValue).Name));
        }

        return ruleBuilder
            .Must((command, val) => val.CompareTo(value) > 0)
            .WithMessageAuto(ResourceValidation.Greater_Than, value.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TValue?> GreaterThanAuto<T, TValue>(this IRuleBuilder<T, TValue?> ruleBuilder, TValue value, Func<T, bool> condition = null)
        where TValue : struct, IComparable<TValue>
    {
        if (!Common.Extensions.Extensions.IsNumericType(typeof(TValue)))
            throw new InvalidOperationException(ResourceValidation.Not_Numeric_Type.AppendArgument(typeof(TValue).Name));

        return ruleBuilder
            .Must((command, val) => val.HasValue && val.Value.CompareTo(value) > 0)
            .WithMessageAuto(ResourceValidation.Greater_Than, value.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TValue> LessThanAuto<T, TValue>(this IRuleBuilder<T, TValue> ruleBuilder, TValue value, Func<T, bool> condition = null)
        where TValue : struct, IComparable<TValue>
    {
        if (!Common.Extensions.Extensions.IsNumericType(typeof(TValue)))
        {
            throw new InvalidOperationException(ResourceValidation.Not_Numeric_Type.AppendArgument(typeof(TValue).Name));
        }

        return ruleBuilder
            .Must((command, val) => val.CompareTo(value) < 0)
            .WithMessageAuto(ResourceValidation.Less_Than, value.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TValue?> LessThanAuto<T, TValue>(this IRuleBuilder<T, TValue?> ruleBuilder, TValue value, Func<T, bool> condition = null)
        where TValue : struct, IComparable<TValue>
    {
        if (!Common.Extensions.Extensions.IsNumericType(typeof(TValue)))
            throw new InvalidOperationException(ResourceValidation.Not_Numeric_Type.AppendArgument(typeof(TValue).Name));

        return ruleBuilder
            .Must((command, val) => val.HasValue && val.Value.CompareTo(value) < 0)
            .WithMessageAuto(ResourceValidation.Less_Than, value.ToString())
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, TProperty> IsInEnumAuto<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<T, bool> condition = null)
        where TProperty : struct, Enum
    {
        return ruleBuilder.Must((command, value) =>
        {
            var type = typeof(TProperty);

            return !type.IsEnum
                ? throw new InvalidOperationException(ResourceValidation.Not_Expected_Enum_Type.AppendArgument(type.Name))
                : value.IsDefined();
        })
        .WithMessageAuto(ResourceValidation.Not_Expected_Enum_Type, typeof(TProperty).Name)
        .When(_ => condition?.Invoke(_) ?? true);
    }

    // Matchings

    public static IRuleBuilderOptions<T, string> MatchesPassword<T>(this IRuleBuilderOptions<T, string> ruleBuilder)
        => ruleBuilder.MatchesAuto(Constants.REGEX_PASSWORD, ResourceValidation.Password);

    public static IRuleBuilderOptions<T, string> MatchesPhone<T>(this IRuleBuilder<T, string> ruleBuilder, Func<T, bool> condition = null)
    {
        return ruleBuilder.MatchesAuto(Constants.REGEX_PHONE_NUMBER, ResourceValidation.Phone_Number)
            .When(_ => condition?.Invoke(_) ?? true);
    }

    public static IRuleBuilderOptions<T, string> MatchesAuto<T>(this IRuleBuilder<T, string> ruleBuilder, Regex pattern, string resourceValidation)
        => ruleBuilder.Matches(pattern).WithMessageAuto(resourceValidation);

    // Equal

    public static IRuleBuilderOptions<T, TProperty> EqualAuto<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, Expression<Func<T, TProperty>> propertySelector)
    {
        var propertyName = propertySelector.GetDisplayName();

        return ruleBuilder
            .Equal(propertySelector)
            .WithMessageAuto(ResourceValidation.Dont_Match, propertyName);
    }

    // Message

    public static IRuleBuilderOptions<T, TProperty> WithMessageAuto<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string resourceValidation, params string[] args)
    {
        return ruleBuilder.WithMessage((command, value) =>
        {
            var propertyName = ruleBuilder.GetPropertyName();

            var name = GetDisplayNameFromCommand(command, propertyName);

            var allArgs = new string[args.Length + 1];
            allArgs[0] = name;

            for (int i = 0; i < args.Length; i++)
                allArgs[i + 1] = args[i];

            return resourceValidation.AppendArgument(allArgs);
        });
    }

    // Email

    public static IRuleBuilderOptions<T, string> EmailAddressAuto<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.EmailAddress().WithMessageAuto(ResourceValidation.Wrong_Format);

    // private

    private static string GetPropertyName<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder)
    {
        var rule = ruleBuilder.GetType().GetProperty("Rule")?.GetValue(ruleBuilder);

        if (rule != null)
        {
            var member = rule.GetType().GetProperty("Member")?.GetValue(rule);
            if (member != null)
            {
                var name = member.GetType().GetProperty("Name")?.GetValue(member) as string;
                return name; // This is the property name (e.g., "FirstName")
            }
        }

        throw new InvalidOperationException("Could not extract the property name from the rule builder.");
    }

    private static string GetDisplayNameFromCommand<T>(T command, string propertyName)
    {
        var data = GetDtoFromCommand(command);

        if (data != null)
        {
            var propertyInfo = data.GetType().GetProperty(propertyName);

            if (propertyInfo != null)
            {
                if (propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), false)
                    .FirstOrDefault() is DisplayAttribute displayAttribute)
                {
                    return displayAttribute.Name ?? propertyInfo.Name;
                }

                if (propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() is DescriptionAttribute descriptionAttribute)
                {
                    return descriptionAttribute?.Description ?? propertyInfo.Name;
                }
            }
        }

        return propertyName;
    }

    private static object GetDtoFromCommand<T>(T command)
    {
        // Assuming the DTO is a property inside the command (e.g., `command.User`)
        var dtoProperty = command.GetType().GetProperties()
            .FirstOrDefault(prop => prop.PropertyType.IsClass); // Finding the class-type property (the DTO)

        return dtoProperty?.GetValue(command); // Return the DTO object
    }
}