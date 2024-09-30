using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static string ToXml(this object data)
    {
        var serializer = new XmlSerializer(data.GetType());

        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, data);
            return writer.ToString();
        }
    }

    public static string GetPropertyNames<TClass>()
        where TClass : class
    {
        var propertyNames = typeof(TClass).GetProperties().Select(_ => _.Name);

        return string.Join(",", propertyNames);
    }

    public static Dictionary<string, string> GetAllPropertyDescriptions<TClass>()
        where TClass : class
    {
        var type = typeof(TClass);
        var descriptions = new Dictionary<string, string>();

        foreach (var property in type.GetProperties())
        {
            if (property.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() is DescriptionAttribute descriptionAttribute)
                descriptions[property.Name] = descriptionAttribute.Description;
        }

        return descriptions;
    }

    public static string GetPropertyDescription<T>(Expression<Func<T, object>> propertyExpression)
    {
        MemberExpression memberExpression;

        // Check if the expression is Unary (boxing value types like DateTime)
        if (propertyExpression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression unaryMember)
        {
            memberExpression = unaryMember;
        }
        else if (propertyExpression.Body is MemberExpression member)
        {
            memberExpression = member;
        }
        else
        {
            throw new ArgumentException("Expression is not a member access expression.", nameof(propertyExpression));
        }

        var propertyInfo = (PropertyInfo)memberExpression.Member;
        var descriptionAttribute = propertyInfo.GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute?.Description ?? propertyInfo.Name;
    }
}