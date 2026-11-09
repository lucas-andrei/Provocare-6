namespace OvenAlarm.Tests;

// Se execută o dată, după ultimul test din acest namespace.
// NU se modifică. Trece doar dacă nicio rulare de test nu a trimis SMS real.
[SetUpFixture]
public class NoRealSmsFixture
{
    [OneTimeTearDown]
    public void NoRealSmsWasSent()
    {
        Assert.That(SmsGateway.TotalSent, Is.EqualTo(0),
            "Testele au trimis SMS-uri reale.");
    }
}
