using PeakPerformance.Common;
using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Fluent;
using System.Reflection;
using ConfigurationBuilder = Reinforced.Typings.Fluent.ConfigurationBuilder;

namespace PeakPerformance.WebApi.ReinforcedTypings;

public static class FluentConfiguration
{
    private static readonly Action<InterfaceExportBuilder> _interfaceConfiguration = config =>
        config
        .WithPublicProperties()
        .ConfigureTypeMapping()
        .ExportTo("interfaces.ts");

    private static readonly Action<ClassExportBuilder> _serviceConfiguration = config =>
        config
        .AddImport("{ Injectable }", "@angular/core")
        .AddImport("{ HttpParams, HttpClient }", "@angular/common/http")
        .AddImport("{ SettingsService }", "../services/settings.service")
        .AddImport("{ Observable }", "rxjs")
        .AddImport("{ map }", "rxjs/operators")
        .ExportTo("services.ts")
        .WithCodeGenerator<AngularControllerGenerator>();

    private static readonly Action<EnumExportBuilder> _enumProviderConfiguration = config =>
        config
        .AddImport("{ Injectable }", "@angular/core")
        .AddImport("{ IEnumProvider }", "./interfaces")
        .ExportTo("providers.ts")
        .WithCodeGenerator<EnumProviderGenerator>();

    public static void Configure(ConfigurationBuilder builder)
    {
        builder.Global(config => config.CamelCaseForProperties()
                                .DontWriteWarningComment()
                               .AutoOptionalProperties()
                               .UseModules());

        // Enums

        var commonAssembly = Assembly.Load($"{Constants.SOLUTION_NAME}.Common");
        var enums = commonAssembly
            .GetTypes()
            .Where(t => t.IsEnum && t.Namespace != null && t.Namespace.Contains($"{Constants.SOLUTION_NAME}.Common.Enums"));

        builder.ExportAsEnums(enums,
            config =>
                config.DontIncludeToNamespace()
                .ExportTo("enums.ts")
            );

        // Dtos

        var applicationAssembly = Assembly.Load($"{Constants.SOLUTION_NAME}.Application");
        var dtos = applicationAssembly
            .GetTypes()
            .Where(t => t.IsClass
                && t.Namespace != null
                && t.Namespace.Contains($"{Constants.SOLUTION_NAME}.Application.Dtos")
                && t.Name.EndsWith("Dto"));

        var additionalInterfaces = new List<Type>([typeof(IEnumProvider)]);

        builder.ExportAsInterfaces(
            dtos.Concat(additionalInterfaces)
            .OrderBy(i => i.Name)
            .ToArray(),
            _interfaceConfiguration
            );

        builder.ExportAsInterfaces(
            Assembly.GetAssembly(typeof(Domain._Grid.PagingResult<>)).ExportedTypes
            .Where(i => i.Namespace.StartsWith($"{Constants.SOLUTION_NAME}.Domain._Grid") && i.IsClass)
            .OrderBy(i => i.Name)
            .OrderBy(i => i.Name != nameof(Domain._Grid.PagingResult<object>))
            .ToArray(),
            _interfaceConfiguration
            );

        builder.ExportAsInterfaces(
            Assembly.GetAssembly(typeof(Domain.Searches.WeightSearchOptions)).ExportedTypes
            .Where(i => i.Namespace.StartsWith($"{Constants.SOLUTION_NAME}.Domain.Searches") && i.IsClass)
            .OrderBy(i => i.Name)
            .OrderBy(i => i.Name != nameof(Domain.Searches.WeightSearchOptions))
            .ToArray(),
            _interfaceConfiguration
            );

        // Enums

        builder.ExportAsEnums(
            [typeof(Providers)],
            _enumProviderConfiguration
            );

        // Controllers

        builder.ExportAsClasses(
            Assembly.GetAssembly(typeof(BaseController)).ExportedTypes
            .Where(i => i.Namespace.StartsWith($"{Constants.SOLUTION_NAME}.WebApi.Controllers"))
            .OrderBy(i => i.Name)
            .OrderBy(i => i.Name != nameof(BaseController))
            .ToArray(),
            _serviceConfiguration
            );
    }

    private static TBuilder ConfigureTypeMapping<TBuilder>(this TBuilder config)
        where TBuilder : ClassOrInterfaceExportBuilder
    {
        config
            .Substitute(typeof(Guid), new RtSimpleTypeName("string"))
            .Substitute(typeof(Guid?), new RtSimpleTypeName("string | null"))
            .Substitute(typeof(DateTime), new RtSimpleTypeName("Date"))
            .Substitute(typeof(DateTime?), new RtSimpleTypeName("Date | null"))
            .Substitute(typeof(DateOnly), new RtSimpleTypeName("Date"))
            .Substitute(typeof(DateOnly?), new RtSimpleTypeName("Date | null"));

        return config;
    }
}