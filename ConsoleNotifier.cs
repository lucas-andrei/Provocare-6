namespace OvenAlarm;
public class ConsoleNotifier: INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"[CONSOLE] {message}");
    }
}