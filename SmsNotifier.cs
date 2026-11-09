namespace OvenAlarm;
public class SmsNotifier: INotifier
{
    private readonly SmsGateway gateway;
    public SmsNotifier(string phoneNumber)
    {
        gateway = new SmsGateway(phoneNumber);
    }

    public void Send(string message)
    {
        gateway.Send(message);
    }
}