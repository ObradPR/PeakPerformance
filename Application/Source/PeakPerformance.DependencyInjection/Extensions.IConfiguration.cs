using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace PeakPerformance.DependencyInjection;

public static partial class Extensions
{
    private static IConfiguration CreateSecretConfiguration()
    {
        return new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();
    }
}