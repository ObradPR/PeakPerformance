using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static string ToJson(this object data)
        => JsonConvert.SerializeObject(data);

    public static string ToXml(this object data)
    {
        var serializer = new XmlSerializer(data.GetType());

        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, data);
            return writer.ToString();
        }
    }

    public static bool IsValidJson(this string json)
    {
        json = json.Trim();

        if ((json.StartsWith("{") && json.EndsWith("}")) || (json.StartsWith("[") && json.EndsWith("]")))
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<object>(json);
                return true;
            }
            catch { }
        }

        return false;
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
}