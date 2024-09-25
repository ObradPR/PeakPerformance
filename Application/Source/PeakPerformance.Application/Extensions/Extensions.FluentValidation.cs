namespace PeakPerformance.Application.Extensions;

public static partial class Extensions
{
    public static IRuleBuilderOptions<T, TProperty> WithMessageAuto<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string resourceValidation, params string[] args)
    {
        return ruleBuilder.WithMessage((ctx, value) =>
        {
            var validationContext = ctx as ValidationContext<T>
                ?? throw new InvalidOperationException(ResourceValidation.Not_Expected_Type.AppendArgument("Validation Context"));

            var name = GetDisplayNameFromContext(validationContext);

            var allArgs = new string[args.Length + 1];
            allArgs[0] = name;

            for (int i = 0; i < args.Length; i++)
                allArgs[i + 1] = args[i];

            return resourceValidation.AppendArgument(allArgs);
        });
    }

    // private

    private static string GetDisplayNameFromContext<T>(ValidationContext<T> context)
    {
        var memberName = context.PropertyName;
        var propertyInfo = typeof(T).GetProperty(memberName);

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

        return memberName;
    }
}