using PeakPerformance.Common;
using PeakPerformance.Persistence.Contexts;
using System.Reflection;

namespace PeakPerformance.Test;

internal class SandBox
{
    private ApplicationDbContext db;

    [SetUp]
    public void SetUp()
    {
        db = new ApplicationDbContext(null);
    }

    [Test]
    public async Task SandBoxOPR()
    {
        var applicationAssembly = Assembly.Load($"{Constants.SOLUTION_NAME}.Application");
        var dtos = applicationAssembly
            .GetTypes()
            .Where(t => t.IsClass
                && t.Namespace != null
                && t.Namespace.Contains($"{Constants.SOLUTION_NAME}.Application.Dtos"));
    }

    [TearDown]
    public void TearDown()
    {
        db.Dispose();
    }
}