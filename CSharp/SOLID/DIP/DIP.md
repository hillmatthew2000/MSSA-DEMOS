# Dependency Inversion Principle (DIP)

## Definition
The Dependency Inversion Principle states that:
1. **High-level modules should not depend on low-level modules. Both should depend on abstractions.**
2. **Abstractions should not depend on details. Details should depend on abstractions.**

In simpler terms: Depend on interfaces/abstractions, not concrete implementations.

## Why It's Important

### 1. **Loose Coupling**
- High-level logic isn't tied to specific implementations
- Easy to swap implementations without changing business logic
- Reduces ripple effects when low-level details change

### 2. **Testability**
- Easy to mock dependencies for unit testing
- Can test business logic in isolation
- Faster test execution with fake implementations

### 3. **Flexibility**
- Different implementations for different environments (dev, test, prod)
- Easy to add new implementations
- Runtime configuration of dependencies

### 4. **Maintainability**
- Changes to implementation details don't affect business logic
- Clear separation between "what" and "how"
- Easier to understand and modify code

## Code Example Analysis

### ❌ **Bad Example (DIP Violation)**
```csharp
public class FileManager
{
    private readonly LocalStorage _storage = new LocalStorage();  // 📍 CONCRETE DEPENDENCY

    public void SaveDocument(string name, string content)
    {
        Console.WriteLine($"[FileManager] Saving document '{name}'...");
        _storage.WriteFile(name, content);  // 📍 TIED TO LOCAL STORAGE
    }

    public void DeleteDocument(string name)
    {
        Console.WriteLine($"[FileManager] Deleting document '{name}'...");
        _storage.DeleteFile(name);
    }
}

public class LocalStorage
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
```

**Problems:**
- **Tight coupling**: `FileManager` is married to `LocalStorage`
- **Hard to test**: Can't test file management without actual file operations
- **Inflexible**: Can't use cloud storage, database, or memory storage
- **Dependency direction**: High-level (`FileManager`) depends on low-level (`LocalStorage`)

### ✅ **Good Example (DIP Compliant)**
```csharp
// Abstraction that both high and low level modules depend on
public interface IStorage
{
    void WriteFile(string filename, string content);
    void DeleteFile(string filename);
}

// High-level module depends on abstraction
public class FileManager
{
    private readonly IStorage _storage;
    
    public FileManager(IStorage storage)  // 📍 DEPENDS ON ABSTRACTION
    {
        _storage = storage;
    }

    public void SaveDocument(string name, string content)
    {
        Console.WriteLine($"[FileManager] Saving document '{name}'...");
        _storage.WriteFile(name, content);  // 📍 USES INTERFACE
    }

    public void DeleteDocument(string name)
    {
        Console.WriteLine($"[FileManager] Deleting document '{name}'...");
        _storage.DeleteFile(name);
    }
}

// Low-level modules also depend on abstraction
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
        Console.WriteLine($"[RemoteStorage] '{filename}' uploaded with content: {content}");
    }

    public void DeleteFile(string filename)
    {
        Console.WriteLine($"[RemoteStorage] '{filename}' deleted from cloud.");
    }
}

// Usage - can choose implementation at runtime
class Program
{
    static void Main(string[] args)
    {
        IStorage localStorage = new LocalStorage();
        var manager1 = new FileManager(localStorage);
        
        IStorage remoteStorage = new RemoteStorage();
        var manager2 = new FileManager(remoteStorage);
        
        // Same FileManager, different storage implementations!
    }
}
```

**Benefits:**
- **Loose coupling**: `FileManager` doesn't know about specific storage types
- **Easy testing**: Can inject mock storage for unit tests
- **Flexible**: Can use any storage implementation
- **Proper dependency direction**: Both depend on `IStorage` abstraction

## Real-World Applications

### E-commerce Order Processing

#### ❌ **DIP Violation**
```csharp
public class OrderProcessor
{
    private EmailService _emailService = new EmailService();
    private SqlDatabase _database = new SqlDatabase();
    private PayPalGateway _paymentGateway = new PayPalGateway();
    
    public void ProcessOrder(Order order)
    {
        // Business logic tightly coupled to specific implementations
        _paymentGateway.ProcessPayment(order.Amount);
        _database.SaveOrder(order);
        _emailService.SendConfirmation(order.CustomerEmail);
    }
}
```

#### ✅ **DIP Compliant**
```csharp
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public interface IOrderRepository
{
    void SaveOrder(Order order);
}

public interface IPaymentGateway
{
    PaymentResult ProcessPayment(decimal amount, string cardDetails);
}

public class OrderProcessor
{
    private readonly IEmailService _emailService;
    private readonly IOrderRepository _repository;
    private readonly IPaymentGateway _paymentGateway;
    
    public OrderProcessor(
        IEmailService emailService,
        IOrderRepository repository,
        IPaymentGateway paymentGateway)
    {
        _emailService = emailService;
        _repository = repository;
        _paymentGateway = paymentGateway;
    }
    
    public void ProcessOrder(Order order)
    {
        // Business logic independent of implementation details
        var result = _paymentGateway.ProcessPayment(order.Amount, order.CardDetails);
        if (result.Success)
        {
            _repository.SaveOrder(order);
            _emailService.SendEmail(order.CustomerEmail, "Order Confirmed", "...");
        }
    }
}

// Different implementations can be injected
public class EmailService : IEmailService { /* SMTP implementation */ }
public class SmsService : IEmailService { /* SMS implementation */ }
public class SqlOrderRepository : IOrderRepository { /* SQL implementation */ }
public class MongoOrderRepository : IOrderRepository { /* MongoDB implementation */ }
```

### Data Access Layer Example

#### ❌ **DIP Violation**
```csharp
public class UserService
{
    private SqlConnection _connection = new SqlConnection("...");
    
    public User GetUser(int id)
    {
        // Directly using SQL Server classes
        var command = new SqlCommand($"SELECT * FROM Users WHERE Id = {id}", _connection);
        // ... SQL specific code
    }
}
```

#### ✅ **DIP Compliant**
```csharp
public interface IUserRepository
{
    User GetById(int id);
    void Save(User user);
    void Delete(int id);
}

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User GetUser(int id)
    {
        return _userRepository.GetById(id);
    }
}

// Multiple implementations possible
public class SqlUserRepository : IUserRepository { /* SQL Server */ }
public class MongoUserRepository : IUserRepository { /* MongoDB */ }
public class InMemoryUserRepository : IUserRepository { /* For testing */ }
```

## Dependency Injection Patterns

### 1. **Constructor Injection** (Recommended)
```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly IEmailService _emailService;
    
    public OrderService(IOrderRepository repository, IEmailService emailService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
    }
}
```

### 2. **Property Injection**
```csharp
public class OrderService
{
    public IOrderRepository Repository { get; set; }
    public IEmailService EmailService { get; set; }
    
    public void ProcessOrder(Order order)
    {
        if (Repository == null) throw new InvalidOperationException("Repository not set");
        // ... use dependencies
    }
}
```

### 3. **Method Injection**
```csharp
public class OrderService
{
    public void ProcessOrder(Order order, IOrderRepository repository, IEmailService emailService)
    {
        // Dependencies passed as method parameters
    }
}
```

## IoC Container Example

### Setup with Dependency Injection Container
```csharp
// Configuration (usually in Startup.cs or Program.cs)
public void ConfigureServices(IServiceCollection services)
{
    // Register interfaces with implementations
    services.AddScoped<IOrderRepository, SqlOrderRepository>();
    services.AddScoped<IEmailService, SmtpEmailService>();
    services.AddScoped<IPaymentGateway, StripePaymentGateway>();
    services.AddScoped<OrderProcessor>();
}

// Usage - container automatically injects dependencies
public class OrderController
{
    private readonly OrderProcessor _orderProcessor;
    
    public OrderController(OrderProcessor orderProcessor)
    {
        _orderProcessor = orderProcessor; // All dependencies auto-injected!
    }
}
```

### Environment-Specific Configuration
```csharp
public void ConfigureServices(IServiceCollection services)
{
    if (Environment.IsDevelopment())
    {
        services.AddScoped<IEmailService, MockEmailService>();
        services.AddScoped<IOrderRepository, InMemoryOrderRepository>();
    }
    else
    {
        services.AddScoped<IEmailService, SmtpEmailService>();
        services.AddScoped<IOrderRepository, SqlOrderRepository>();
    }
}
```

## Testing Benefits of DIP

### Unit Testing with Mocks
```csharp
[Test]
public void ProcessOrder_ShouldSaveOrder_WhenPaymentSucceeds()
{
    // Arrange
    var mockRepository = new Mock<IOrderRepository>();
    var mockEmailService = new Mock<IEmailService>();
    var mockPaymentGateway = new Mock<IPaymentGateway>();
    
    mockPaymentGateway
        .Setup(x => x.ProcessPayment(It.IsAny<decimal>(), It.IsAny<string>()))
        .Returns(new PaymentResult { Success = true });
    
    var processor = new OrderProcessor(
        mockEmailService.Object,
        mockRepository.Object,
        mockPaymentGateway.Object);
    
    var order = new Order { Amount = 100, CustomerEmail = "test@example.com" };
    
    // Act
    processor.ProcessOrder(order);
    
    // Assert
    mockRepository.Verify(x => x.SaveOrder(order), Times.Once);
    mockEmailService.Verify(x => x.SendEmail(
        order.CustomerEmail, 
        It.IsAny<string>(), 
        It.IsAny<string>()), Times.Once);
}
```

## Common DIP Implementation Patterns

### 1. **Factory Pattern**
```csharp
public interface IStorageFactory
{
    IStorage CreateStorage(StorageType type);
}

public class StorageFactory : IStorageFactory
{
    public IStorage CreateStorage(StorageType type) => type switch
    {
        StorageType.Local => new LocalStorage(),
        StorageType.Cloud => new CloudStorage(),
        StorageType.Database => new DatabaseStorage(),
        _ => throw new ArgumentException("Unknown storage type")
    };
}
```

### 2. **Service Locator Pattern** (Use Sparingly)
```csharp
public class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new();
    
    public static void Register<T>(T implementation)
    {
        _services[typeof(T)] = implementation;
    }
    
    public static T Get<T>()
    {
        return (T)_services[typeof(T)];
    }
}
```

### 3. **Abstract Factory Pattern**
```csharp
public interface IDataAccessFactory
{
    IUserRepository CreateUserRepository();
    IOrderRepository CreateOrderRepository();
}

public class SqlDataAccessFactory : IDataAccessFactory
{
    public IUserRepository CreateUserRepository() => new SqlUserRepository();
    public IOrderRepository CreateOrderRepository() => new SqlOrderRepository();
}
```

## Key Takeaways

1. **Depend on abstractions, not concretions**
2. **Inject dependencies rather than creating them**
3. **High-level modules should not depend on low-level modules**
4. **Use interfaces to define contracts**
5. **Favor composition over inheritance**

## Common DIP Violations to Avoid

- **New keyword in constructors** for dependencies
- **Static method calls** to external services
- **Hard-coded file paths, connection strings**
- **Direct database access** from business logic
- **Framework-specific code** in business logic

## Benefits Summary

| Aspect | Without DIP | With DIP |
|--------|-------------|----------|
| **Coupling** | Tight (hard-coded dependencies) | Loose (injected abstractions) |
| **Testing** | Difficult (real dependencies) | Easy (mock dependencies) |
| **Flexibility** | Limited (fixed implementations) | High (swappable implementations) |
| **Maintenance** | Changes ripple through layers | Changes isolated to implementations |
| **Configuration** | Compile-time decisions | Runtime configuration |

## Best Practices

- **Constructor injection** for required dependencies
- **Property injection** for optional dependencies
- **Validate dependencies** in constructors (null checks)
- **Use IoC containers** for automatic dependency resolution
- **Keep interfaces focused** and minimal
- **Avoid service locator** pattern when possible
- **Register dependencies** at application startup

DIP is the foundation for flexible, testable, and maintainable applications. It enables true separation of concerns and makes your code adaptable to changing requirements!