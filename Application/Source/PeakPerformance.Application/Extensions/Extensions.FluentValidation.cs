namespace PeakPerformance.Application.Extensions;

public static partial class Extensions
{
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