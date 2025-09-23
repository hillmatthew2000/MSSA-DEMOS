# Interface Segregation Principle (ISP)

## Definition
The Interface Segregation Principle states that **no class should be forced to implement interfaces it doesn't use**. In other words, many client-specific interfaces are better than one general-purpose interface.

## Why It's Important

### 1. **Reduces Coupling**
- Classes only depend on methods they actually need
- Changes to unused methods don't affect implementing classes
- Smaller, focused interfaces create loose coupling

### 2. **Improves Maintainability**
- Easier to understand what a class actually needs
- Changes impact fewer classes
- Clearer contracts and responsibilities

### 3. **Enhances Flexibility**
- Classes can implement multiple small interfaces as needed
- Easy to add new capabilities without affecting existing code
- Better composition possibilities

### 4. **Prevents Interface Pollution**
- Avoids bloated interfaces with unrelated methods
- Each interface has a clear, single purpose
- Reduces the temptation to add "just one more method"

## Code Example Analysis

### ❌ **Bad Example (ISP Violation)**
```csharp
public interface IWorker
{
    void Work();
    void Eat();      // 📍 NOT ALL WORKERS EAT
}

public class Robot : IWorker
{
    public void Work() => Console.WriteLine("Robot is working");
    
    public void Eat() => throw new NotImplementedException();  // 📍 FORCED TO IMPLEMENT
    // Robots don't eat! But the interface forces this implementation
}

public class Human : IWorker
{
    public void Work() => Console.WriteLine("Human working...");
    public void Eat() => Console.WriteLine("Human eating...");
}
```

**Problems:**
- **Forced implementation**: `Robot` must implement `Eat()` even though it's meaningless
- **Fat interface**: `IWorker` tries to do too much
- **Tight coupling**: Changes to eating behavior affect all workers
- **Confusing contract**: Interface suggests all workers eat

### ✅ **Good Example (ISP Compliant)**
```csharp
// Separate, focused interfaces
public interface IWork
{
    void Work();
}

public interface IEat
{
    void Eat();
}

// Implement only what makes sense
public class Human : IWork, IEat
{
    public void Work() => Console.WriteLine("Human working...");
    public void Eat() => Console.WriteLine("Human eating...");
}

public class Robot : IWork
{
    public void Work() => Console.WriteLine("Robot working...");
    // No Eat() method - robots don't need to eat!
}

// Usage is clear and type-safe
public void ManageWorkers(IWork[] workers)
{
    foreach (var worker in workers)
    {
        worker.Work(); // All workers can work
    }
}

public void FeedEmployees(IEat[] eaters)
{
    foreach (var eater in eaters)
    {
        eater.Eat(); // Only things that eat
    }
}
```

**Benefits:**
- **Natural implementation**: Each class implements only relevant methods
- **Clear contracts**: Interfaces express exactly what they provide
- **Flexible composition**: Can mix and match capabilities
- **No forced dependencies**: Classes only depend on what they use

## Real-World Applications

### Document Processing Example

#### ❌ **ISP Violation**
```csharp
public interface IDocument
{
    void Print();
    void Scan();
    void Fax();
    void Email();
}

public class SimplePrinter : IDocument
{
    public void Print() => Console.WriteLine("Printing...");
    
    // Forced to implement features it doesn't have! 😱
    public void Scan() => throw new NotSupportedException();
    public void Fax() => throw new NotSupportedException();
    public void Email() => throw new NotSupportedException();
}

public class MultiFunctionPrinter : IDocument
{
    public void Print() => Console.WriteLine("Printing...");
    public void Scan() => Console.WriteLine("Scanning...");
    public void Fax() => Console.WriteLine("Faxing...");
    public void Email() => Console.WriteLine("Emailing...");
}
```

#### ✅ **ISP Compliant**
```csharp
// Segregated interfaces
public interface IPrint
{
    void Print();
}

public interface IScan
{
    void Scan();
}

public interface IFax
{
    void Fax();
}

public interface IEmail
{
    void Email();
}

// Implement only what you have
public class SimplePrinter : IPrint
{
    public void Print() => Console.WriteLine("Printing...");
}

public class Scanner : IScan
{
    public void Scan() => Console.WriteLine("Scanning...");
}

public class MultiFunctionPrinter : IPrint, IScan, IFax, IEmail
{
    public void Print() => Console.WriteLine("Printing...");
    public void Scan() => Console.WriteLine("Scanning...");
    public void Fax() => Console.WriteLine("Faxing...");
    public void Email() => Console.WriteLine("Emailing...");
}

// Client code is more focused
public class DocumentProcessor
{
    public void ProcessDocument(IPrint printer)
    {
        printer.Print(); // Only needs printing capability
    }
    
    public void DigitizeDocument(IScan scanner)
    {
        scanner.Scan(); // Only needs scanning capability
    }
}
```

### Payment Processing Example

#### ❌ **ISP Violation**
```csharp
public interface IPaymentProcessor
{
    void ProcessCreditCard(string cardNumber);
    void ProcessPayPal(string email);
    void ProcessBankTransfer(string accountNumber);
    void ProcessCrypto(string walletAddress);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessCreditCard(string cardNumber) => 
        Console.WriteLine($"Processing card: {cardNumber}");
    
    // Forced to implement irrelevant methods! 😱
    public void ProcessPayPal(string email) => throw new NotImplementedException();
    public void ProcessBankTransfer(string accountNumber) => throw new NotImplementedException();
    public void ProcessCrypto(string walletAddress) => throw new NotImplementedException();
}
```

#### ✅ **ISP Compliant**
```csharp
public interface ICreditCardProcessor
{
    void ProcessCreditCard(string cardNumber);
}

public interface IPayPalProcessor
{
    void ProcessPayPal(string email);
}

public interface IBankTransferProcessor
{
    void ProcessBankTransfer(string accountNumber);
}

public interface ICryptoProcessor
{
    void ProcessCrypto(string walletAddress);
}

// Clean, focused implementations
public class CreditCardProcessor : ICreditCardProcessor
{
    public void ProcessCreditCard(string cardNumber) => 
        Console.WriteLine($"Processing card: {cardNumber}");
}

public class PayPalProcessor : IPayPalProcessor
{
    public void ProcessPayPal(string email) => 
        Console.WriteLine($"Processing PayPal: {email}");
}

// Can combine multiple payment methods if needed
public class ComboPaymentProcessor : ICreditCardProcessor, IPayPalProcessor
{
    public void ProcessCreditCard(string cardNumber) => 
        Console.WriteLine($"Processing card: {cardNumber}");
    
    public void ProcessPayPal(string email) => 
        Console.WriteLine($"Processing PayPal: {email}");
}
```

## Design Strategies for ISP Compliance

### 1. **Role-Based Interface Design**
```csharp
// Instead of one large interface
public interface IEmployee { /* 20 methods */ }

// Create role-based interfaces
public interface IManager
{
    void ManageTeam();
    void SetBudget(decimal amount);
}

public interface IDeveloper
{
    void WriteCode();
    void ReviewCode();
}

public interface ITeamLead : IDeveloper, IManager
{
    // Combines relevant roles
}
```

### 2. **Capability-Based Interfaces**
```csharp
public interface IReadable<T>
{
    T Read();
}

public interface IWritable<T>
{
    void Write(T item);
}

public interface IDeletable
{
    void Delete();
}

// Combine as needed
public class FileRepository<T> : IReadable<T>, IWritable<T>, IDeletable
{
    public T Read() { /* implementation */ }
    public void Write(T item) { /* implementation */ }
    public void Delete() { /* implementation */ }
}

public class ReadOnlyRepository<T> : IReadable<T>
{
    public T Read() { /* implementation */ }
    // No write or delete - doesn't need those capabilities
}
```

### 3. **Layer-Specific Interfaces**
```csharp
// Data access layer
public interface IUserRepository
{
    User GetById(int id);
    void Save(User user);
}

// Business logic layer
public interface IUserService
{
    void RegisterUser(string email);
    bool ValidateUser(string email);
}

// Presentation layer
public interface IUserController
{
    ActionResult Register(UserModel model);
    ActionResult Login(LoginModel model);
}
```

## ISP in Modern Development

### Dependency Injection with ISP
```csharp
// Good: Inject only what you need
public class OrderService
{
    private readonly IEmailSender _emailSender;
    private readonly IOrderRepository _repository;
    
    public OrderService(IEmailSender emailSender, IOrderRepository repository)
    {
        _emailSender = emailSender;
        _repository = repository;
    }
}

// Rather than injecting a huge service with everything
```

### API Design with ISP
```csharp
// Instead of one large API contract
public interface IUserApi { /* 50 methods */ }

// Segregate by functionality
public interface IUserRegistration
{
    Task<User> RegisterAsync(UserRegistrationDto dto);
}

public interface IUserAuthentication
{
    Task<AuthResult> LoginAsync(LoginDto dto);
    Task LogoutAsync();
}

public interface IUserProfile
{
    Task<UserProfile> GetProfileAsync(int userId);
    Task UpdateProfileAsync(UserProfile profile);
}
```

## Testing Benefits of ISP

### Easier Mocking
```csharp
// Easy to mock small, focused interfaces
var mockEmailSender = new Mock<IEmailSender>();
var mockRepository = new Mock<IOrderRepository>();

var service = new OrderService(mockEmailSender.Object, mockRepository.Object);

// vs. mocking a large interface with many irrelevant methods
```

### Focused Test Cases
```csharp
[Test]
public void ProcessOrder_ShouldSendEmail()
{
    // Only need to mock email functionality
    var mockEmailSender = new Mock<IEmailSender>();
    var service = new OrderService(mockEmailSender.Object, /* other deps */);
    
    service.ProcessOrder(order);
    
    mockEmailSender.Verify(x => x.SendEmail(It.IsAny<string>()), Times.Once);
}
```

## Key Takeaways

1. **Many small interfaces > One large interface**
2. **Clients should only depend on methods they use**
3. **Interfaces should be cohesive and focused**
4. **Composition becomes easier with small interfaces**
5. **Testing and mocking become simpler**

## Common ISP Violations to Avoid

- **God interfaces** with dozens of methods
- **Mixed concerns** in single interface (data + formatting + validation)
- **Convenience methods** that don't belong conceptually
- **"While we're here"** additions to existing interfaces
- **Inheritance-based interface design** (inheriting large interfaces)

## Benefits Summary

| Aspect | Fat Interfaces | Segregated Interfaces |
|--------|----------------|----------------------|
| **Implementation Burden** | High (must implement all) | Low (implement only needed) |
| **Coupling** | Tight (many dependencies) | Loose (minimal dependencies) |
| **Testing** | Complex (large mocks) | Simple (focused mocks) |
| **Flexibility** | Limited (all-or-nothing) | High (mix and match) |
| **Understanding** | Difficult (what's relevant?) | Clear (obvious purpose) |

## Best Practices

- **Start small** - Begin with minimal interfaces
- **Group by client needs** - What do specific clients actually use?
- **Use composition** - Combine small interfaces when needed
- **Regular review** - Refactor interfaces that grow too large
- **Think about callers** - Design interfaces from the client's perspective

ISP helps create clean, maintainable code by ensuring that dependencies are minimal and purposeful!