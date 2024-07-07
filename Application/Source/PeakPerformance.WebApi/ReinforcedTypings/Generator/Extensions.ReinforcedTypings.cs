using Reinforced.Typings.Ast.TypeNames;

namespace PeakPerformance.WebApi.ReinforcedTypings.Generator;

public static class Extensions
{
    public static bool IsString(this RtTypeName typeName)
    {
        return typeName.ToString().ToLower() == "string";
    }
}