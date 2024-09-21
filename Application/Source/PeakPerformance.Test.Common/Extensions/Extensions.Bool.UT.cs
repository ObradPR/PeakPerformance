using PeakPerformance.Common.Extensions;

namespace PeakPerformance.Test.Common.Extensions;

public class BoolExtensions
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void Toggle()
    {
        bool newValue = false.Toggle();

        Assert.That(newValue, Is.Not.EqualTo(false));
    }

    [Test]
    public void ToInt()
    {
        int intValue = false.ToInt();

        Assert.That(intValue, Is.EqualTo(0));
    }
}