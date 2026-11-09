namespace OvenAlarm;

public interface INotifier
{
    void Send(string message);
}