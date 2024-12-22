using PeakPerformance.Common.Extensions;
using PeakPerformance.Persistence.Contexts;

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
        var date = DateTime.UtcNow;
        var date2 = DateTime.Now;

        var result = date.ConvertToUtc();
        var result2 = date2.ConvertToUtc();
    }

    [TearDown]
    public void TearDown()
    {
        db.Dispose();
    }
}