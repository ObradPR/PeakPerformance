using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Extensions;

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
        var injuryTypes = await db.InjuryTypes.GetListAsync();

        //var user = await db.Users.FirstAsync();

        //db.DeleteSingle(user);

        //await db.SaveChangesAsync();
    }

    [TearDown]
    public void TearDown()
    {
        db.Dispose();
    }
}