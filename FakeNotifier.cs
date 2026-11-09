namespace OvenAlarm.Tests;

public class FakeNotifier : INotifier
{
    public List<string> Messages { get; } = new();

    public int SendCount => Messages.Count;

    public void Send(string message)
    {
        Messages.Add(message);
    }
}