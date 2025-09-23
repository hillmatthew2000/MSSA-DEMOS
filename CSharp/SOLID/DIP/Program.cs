namespace DIP;

/* GOOD EXAMPLE: Follows the Dependency Inversion Principle (DIP)
FileManager depends on the IStorage abstraction, not a concrete storage class.
This allows easy swapping of storage implementations and simplifies testing. */
public class FileManager
{
    private readonly IStorage _storage;
    public FileManager(IStorage storage)
    {
        _storage = storage;
    }

    public void SaveDocument(string name, string content)
    {
        Console.WriteLine($"[FileManager] Saving document '{name}'...");
        _storage.WriteFile(name, content);
    }

    public void DeleteDocument(string name)
    {
        Console.WriteLine($"[FileManager] Deleting document '{name}'...");
        _storage.DeleteFile(name);
    }
}

public interface IStorage
{
    void WriteFile(string filename, string content);
    void DeleteFile(string filename);
}

public class LocalStorage : IStorage
{
    public void WriteFile(string filename, string content)
    {
        Console.WriteLine($"[LocalStorage] '{filename}' saved with content: {content}");
    }

    public void DeleteFile(string filename)
    {
        Console.WriteLine($"[LocalStorage] '{filename}' deleted from disk.");
    }
}

public class RemoteStorage : IStorage
{
    public void WriteFile(string filename, string content)
    {
        Console.WriteLine($"[RemoteStorage] '{filename}' saved with content: {content}");
    }

    public void DeleteFile(string filename)
    {
        Console.WriteLine($"[RemoteStorage] '{filename}' deleted from disk.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IStorage localStorage = new LocalStorage();
        var manager = new FileManager(localStorage);
        manager.SaveDocument("report.txt", "Quarterly data...");
        manager.DeleteDocument("report.txt");
        IStorage remoteStorage = new RemoteStorage();
        var manager2 = new FileManager(remoteStorage);
        manager2.SaveDocument("report2.txt", "Yearly data...");
        manager2.DeleteDocument("report2.txt");
    }
}

/* BAD EXAMPLE: Violates the Dependency Inversion Principle (DIP)
FileManager directly depends on the concrete LocalStorage class. This creates tight coupling 
and makes it hard to switch storage implementations or test FileManager in isolation. */
    
// class Program
// {
//     static void Main()
//     {
//         var manager = new FileManager();
//         manager.SaveDocument("report.txt", "Quarterly data...");
//         manager.DeleteDocument("report.txt");
//     }
// }
// public class FileManager
// {
//     private readonly LocalStorage _storage = new LocalStorage();

//     public void SaveDocument(string name, string content)
//     {
//         Console.WriteLine($"[FileManager] Saving document '{name}'...");
//         _storage.WriteFile(name, content);
//     }

//     public void DeleteDocument(string name)
//     {
//         Console.WriteLine($"[FileManager] Deleting document '{name}'...");
//         _storage.DeleteFile(name);
//     }
// }

// public class LocalStorage
// {
//     public void WriteFile(string filename, string content)
//     {
//         Console.WriteLine($"[LocalStorage] '{filename}' saved with content: {content}");
//     }

//     public void DeleteFile(string filename)
//     {
//         Console.WriteLine($"[LocalStorage] '{filename}' deleted from disk.");
//     }
// }