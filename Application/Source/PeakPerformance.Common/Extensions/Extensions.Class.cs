using Newtonsoft.Json;
using System.Xml.Serialization;

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool IsNull(this object obj)
        => obj == null;

    public static bool IsNotNull(this object obj)
        => obj != null;

    public static string ToJson(this object obj)
        => JsonConvert.SerializeObject(obj);

    public static string ToXml(this object obj)
    {
        XmlSerializer serializer = new XmlSerializer(obj.GetType());

        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, obj);
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
}