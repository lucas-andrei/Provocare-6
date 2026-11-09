using NUnit.Framework;
using OvenAlarm;

namespace OvenAlarm.Tests;

[TestFixture]
public class OvenControllerTests
{
    [Test]
    public void Check_NormalTemperature_NoAlarm()
    {
        // Arrange
        FakeNotifier fake = new();
        OvenController oven = new(fake);

        // Act
        oven.Check(200);

        // Assert
        Assert.That(fake.SendCount, Is.EqualTo(0));
    }

    [Test]
    public void Check_Exactly250_NoAlarm()
    {
        // Arrange
        FakeNotifier fake = new();
        OvenController oven = new(fake);

        // Act
        oven.Check(250);

        // Assert
        Assert.That(fake.SendCount, Is.EqualTo(0));
    }

    [Test]
    public void Check_Above250_SendsAlarm()
    {
        // Arrange
        FakeNotifier fake = new();
        OvenController oven = new(fake);

        // Act
        oven.Check(251);

        // Assert
        Assert.That(fake.SendCount, Is.EqualTo(1));
        Assert.That(fake.Messages[0], Does.Contain("251.0"));
    }

    [Test]
    public void Check_ConsecutiveHighTemperatures_SendsOnlyOneAlarm()
    {
        // Arrange
        FakeNotifier fake = new();
        OvenController oven = new(fake);

        // Act
        oven.Check(260);
        oven.Check(270);
        oven.Check(280);

        // Assert
        Assert.That(fake.SendCount, Is.EqualTo(1));
    }

    [Test]
    public void Check_TemperatureBetween240And250_DoesNotResetAlarm()
    {
        // Arrange
        FakeNotifier fake = new();
        OvenController oven = new(fake);

        // Act
        oven.Check(260);
        oven.Check(245);
        oven.Check(270);

        // Assert
        Assert.That(fake.SendCount, Is.EqualTo(1));
    }

    [Test]
    public void Check_TemperatureBelow240_ResetsAlarm()
    {
        // Arrange
        FakeNotifier fake = new();
        OvenController oven = new(fake);

        // Act
        oven.Check(260);
        oven.Check(239);
        oven.Check(260);

        // Assert
        Assert.That(fake.SendCount, Is.EqualTo(2));
    }

    [Test]
    public void Constructor_NullNotifier_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () => new OvenController(null!));
    }
}