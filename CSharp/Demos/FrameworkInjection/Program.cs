using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FrameworkInjection;

public class Program
{
    static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<IEmailService, EmailService>();
                services.AddSingleton<IUserRepository, UserRepository>();
                services.AddTransient<IUserRegistrationService, UserRegistrationService>();
                services.AddTransient<ConsoleApp>();
            })
            .Build();

        var app = host.Services.GetRequiredService<ConsoleApp>();
        app.Run();
    }
}
 
public class ConsoleApp
{
    private readonly IUserRegistrationService _registrationService;
 
    public ConsoleApp(IUserRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
 
    public void Run()
    {
        _registrationService.RegisterUser("alice@example.com");
    }
 
}
 
public interface IUserRegistrationService
{
    void RegisterUser(string email);
}
 
public class UserRegistrationService : IUserRegistrationService
{
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;
    public UserRegistrationService(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }
    public void RegisterUser(string email)
    {
        _userRepository.AddUser(email);
        _emailService.SendWelcomeEmail(email);
    }
}
 
public interface IUserRepository
{
    void AddUser(string email);
}
public class UserRepository: IUserRepository
{
    public void AddUser(string email)
    {
        Console.WriteLine($"User '{email}' added to the database");
    }
}
 
public interface IEmailService
{
    void SendWelcomeEmail(string email);
}
public class EmailService : IEmailService
{
    public void SendWelcomeEmail(string email)
    {
        Console.WriteLine($"Welcome email sent to {email}");
    }
}