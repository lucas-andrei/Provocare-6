namespace OvenAlarm;

// Supraveghează temperatura cuptorului și trimite o alarmă prin SMS.
// Alarma se trimite o singură dată la depășirea pragului de 250 °C și se
// rearmează abia când temperatura coboară sub 240 °C.
public class OvenController
{
    private const double AlarmAbove = 250;
    private const double ResetBelow = 240;
    public OvenController(INotifier gateway)
    {
        if (gateway == null)
        {
            throw new ArgumentNullException(nameof(gateway));
        }
        this.gateway = gateway;
        alarmActive = false;
    }
    private readonly INotifier gateway;
    private bool alarmActive;

    public void Check(double tempC)
    {
        if (tempC > AlarmAbove)
        {
            if (!alarmActive)
            {
                gateway.Send($"ALARMĂ: cuptor la {tempC:F1} °C");
                alarmActive = true;
            }
        }
        else if (tempC < ResetBelow)
        {
            alarmActive = false;
        }
    }
}
