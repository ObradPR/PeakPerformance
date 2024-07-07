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

    [Test]
    public void And()
    {
        Assert.Multiple(() =>
        {
            Assert.That(false.And(false), Is.False);
            Assert.That(true.And(false), Is.False);
            Assert.That(false.And(false, true), Is.False);
            Assert.That(true.And(true, true), Is.True);
        });
    }

    [Test]
    public void Or()
    {
        Assert.Multiple(() =>
        {
            Assert.That(false.Or(true), Is.True);
            Assert.That(true.Or(false), Is.True);
            Assert.That(false.Or(true, false), Is.True);
        });
    }

    [Test]
    public void Xor()
    {
        Assert.Multiple(() =>
        {
            Assert.That(false.Xor(true), Is.True);
            Assert.That(false.Xor(false), Is.False);
        });
    }

    [Test]
    public void Nand()
    {
        Assert.Multiple(() =>
        {
            Assert.That(false.Nand(true), Is.True);
            Assert.That(true.Nand(true), Is.False);
            Assert.That(false.Nand(true, false), Is.True);
            Assert.That(true.Nand(true, false), Is.True);
        });
    }

    [Test]
    public void Nor()
    {
        Assert.Multiple(() =>
        {
            Assert.That(false.Nor(true), Is.False);
            Assert.That(true.Nor(true), Is.False);
            Assert.That(false.Nor(false, false), Is.True);
            Assert.That(false.Nor(false, true), Is.False);
        });
    }

    [Test]
    public void Not()
    {
        Assert.That(false.Not(), Is.True);
    }
}