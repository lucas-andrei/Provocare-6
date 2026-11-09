namespace OvenAlarm;

// ============================================================================
//  Driverul furnizorului de SMS-uri (bibliotecă compilată).
//  NU AVEȚI VOIE SĂ MODIFICAȚI ACEST FIȘIER (se verifică prin git diff).
//  Fiecare apel al metodei Send trimite un SMS ADEVĂRAT.
// ============================================================================
public class SmsGateway
{
    private readonly string phoneNumber;

    public SmsGateway(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    // Câte SMS-uri reale au plecat de la pornirea procesului.
    public static int TotalSent { get; private set; }

    public void Send(string text)
    {
        TotalSent++;
        Console.WriteLine($"[SMS REAL -> {phoneNumber}] {text}");
    }
}
