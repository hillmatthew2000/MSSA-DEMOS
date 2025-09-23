# Single Responsibility Principle (SRP)

## Definition
The Single Responsibility Principle states that **a class should have only one reason to change**. In other words, a class should have only one job or responsibility.

## Why It's Important

### 1. **Maintainability**
- Changes to one responsibility don't affect others
- Easier to understand what a class does
- Reduces the risk of introducing bugs when making changes

### 2. **Testability**
- Smaller, focused classes are easier to test
- Each class has a clear, testable responsibility
- Mock dependencies become simpler

### 3. **Reusability**
- Single-purpose classes can be reused in different contexts
- Loose coupling between responsibilities
- Better composition opportunities

### 4. **Code Organization**
- Clear separation of concerns
- Easier to locate specific functionality
- Better project structure

## Code Example Analysis

### ❌ **Bad Example (SRP Violation)**
```csharp
public class UserManager
{
    public void CreateUser(string username)
    {
        Console.WriteLine($"User '{username}' created");
        LogToFile($"User '{username}' created at {DateTime.Now}");  // 📍 PROBLEM
    }
    
    private void LogToFile(string message)  // 📍 SECOND RESPONSIBILITY
    {
        //Imagine this writes to a file
        Console.WriteLine($"[FileLog]: {message}");
    }
}
```

**Problems:**
- `UserManager` has **two responsibilities**: user management AND logging
- If logging requirements change (different format, database logging), we must modify `UserManager`
- Hard to test user creation without also testing file logging
- Violates the "single reason to change" rule

### ✅ **Good Example (SRP Compliant)**
```csharp
public class UserManager
{
    private readonly FileLogger _fileLogger = new FileLogger();
    
    public void CreateUser(string username)
    {
        Console.WriteLine($"User '{username}' created");
        _fileLogger.LogToFile($"User '{username}' created at {DateTime.Now}");
    }
}

public class FileLogger  // 📍 SEPARATE RESPONSIBILITY
{
    public void LogToFile(string message)
    {
        //Imagine this writes to a file
        Console.WriteLine($"[FileLog]: {message}");
    }
}
```

**Benefits:**
- `UserManager` **only** manages users
- `FileLogger` **only** handles file logging
- Can change logging implementation without touching `UserManager`
- Can test user creation independently of logging
- Can reuse `FileLogger` in other classes

## Real-World Applications

### When SRP is Violated
```csharp
// BAD: Employee class doing too much
public class Employee
{
    public void CalculatePay() { /* payroll logic */ }
    public void SaveToDatabase() { /* persistence logic */ }
    public void GenerateReport() { /* reporting logic */ }
}
```

### When SRP is Applied
```csharp
// GOOD: Separated responsibilities
public class Employee { /* only employee data */ }
public class PayrollCalculator { /* only payroll logic */ }
public class EmployeeRepository { /* only persistence */ }
public class ReportGenerator { /* only reporting */ }
```

## Key Takeaways

1. **One class = One responsibility**
2. **One reason to change** per class
3. **High cohesion** within classes
4. **Low coupling** between classes
5. **Easier testing** and maintenance

## Common Signs of SRP Violations

- Class names with "and" (e.g., `UserManagerAndLogger`)
- Large classes with many methods
- Methods that don't relate to the class's primary purpose
- Need to import many different types of dependencies
- Difficulty explaining what the class does in one sentence

## Best Practices

- **Start small**: Begin with focused, single-purpose classes
- **Extract when needed**: If a class grows beyond its responsibility, extract new classes
- **Use dependency injection**: Let classes depend on abstractions, not concrete implementations
- **Think about change**: Ask "What would cause this class to change?"