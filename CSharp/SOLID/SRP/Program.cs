namespace SRP;

/* This is a bad example of SRP because the UserManager class has two responsibilities:
   managing users and logging to a file. This violates the Single Responsibility Principle. */

// class Program
// {
//     static void Main()
//     {
//         var userManager = new UserManager();
//         userManager.CreateUser("alice");
//     }
// }
// public class UserManager
// {
//     public void CreateUser(string username)
//     {
//         Console.WriteLine($"User '{username}' created");
//         LogToFile($"User '{username}' created at {DateTime.Now}");
//     }
//     private void LogToFile(string message)
//     {
//         //Imagine this writes to a file
//         Console.WriteLine($"[FileLog]: {message}");
//     }
// }


/* This is a good example of SRP because the UserManager class has only one responsibility:
   managing users. The logging functionality is separated into its own class, FileLogger. */

class Program
{
    static void Main()
    {
        var userManager = new UserManager();
        userManager.CreateUser("alice");
    }
}
public class UserManager
{
    private readonly FileLogger _fileLogger = new FileLogger();
    public void CreateUser(string username)
    {
        Console.WriteLine($"User '{username}' created");
        _fileLogger.LogToFile($"User '{username}' created at {DateTime.Now}");
    }

}

public class FileLogger
{
    public void LogToFile(string message)
    {
        //Imagine this writes to a file
        Console.WriteLine($"[FileLog]: {message}");
    }
}