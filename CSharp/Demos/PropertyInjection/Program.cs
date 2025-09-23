namespace PropertyInjection;

public class NotificationService
{
    public IMessageService MessageService { get; set;  }
 
    public void SendNotification(string message)
    {
        if (MessageService == null)
            throw new InvalidOperationException("Message service dependency not provided");
        MessageService.Send(message);
    }
}
 
public interface IMessageService
{
    void Send(string message);
}
public class SmsService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}
 
public class MockService: IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"Mock sent: {message}");
    }
}
 
class Program
{
    static void Main()
    {
        var notifier = new NotificationService();
 
        notifier.MessageService = new SmsService();
        notifier.SendNotification("Hello Alice");
 
        notifier.MessageService = new MockService();
        notifier.SendNotification("Hello Bob");
    }
}