using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FrameworkInjection;

public class Program
{
    static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<EmailService>();
                services.AddTransient<UserRegistrationService>();
                services.AddTransient<ConsoleApp>();
            })
            .Build();

        var app = host.Services.GetRequiredService<ConsoleApp>();
        app.Run();
    }
}

public class ConsoleApp
{
    private readonly UserRegistrationService _registrationService;

    public ConsoleApp(UserRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    public void Run()
    {
        _registrationService.RegisterUser("alice@example.com");
    }

}

public class UserRegistrationService
{
    private readonly EmailService _emailService;
    public UserRegistrationService(EmailService emailService)
    {
        _emailService = emailService;
    }
    public void RegisterUser(string email)
    {
        Console.WriteLine($"User '{email}' registered successfully");
        _emailService.SendWelcomeEmail(email);
    }
}


public class EmailService
{
    public void SendWelcomeEmail(string email)
    {
        Console.WriteLine($"Welcome email sent to {email}");
    }
}
 

// public class Program
// {
//     static void Main()
//     {
//         var userRepository = new UserRepository();
//         var emailService = new EmailService();
//         var userRegistrationService = new UserRegistrationService(userRepository, emailService);
//         var app = new ConsoleApp(userRegistrationService);
//         app.Run();
//     }
// }
 
// public class ConsoleApp
// {
//     private readonly UserRegistrationService _registrationService;
 
//     public ConsoleApp(UserRegistrationService registrationService)
//     {
//         _registrationService = registrationService;
//     }
 
//     public void Run()
//     {
//         _registrationService.RegisterUser("alice@example.com");
//     }
 
// }
 
// public class UserRegistrationService
// {
//     private readonly UserRepository _userRepository;
//     private readonly EmailService _emailService;
//     public UserRegistrationService(UserRepository userRepository, EmailService emailService)
//     {
//         _userRepository = userRepository;
//         _emailService = emailService;
//     }
//     public void RegisterUser(string email)
//     {
//         _userRepository.AddUser(email);
//         _emailService.SendWelcomeEmail(email);
//     }
// }
 
// public class UserRepository
// {
//     public void AddUser(string email)
//     {
//         Console.WriteLine($"User '{email}' added to the database");
//     }
// }
 
// public class EmailService
// {
//     public void SendWelcomeEmail(string email)
//     {
//         Console.WriteLine($"Welcome email sent to {email}");
//     }
// }