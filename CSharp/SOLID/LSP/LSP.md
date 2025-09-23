# Liskov Substitution Principle (LSP)

## Definition
The Liskov Substitution Principle states that **objects of a superclass should be replaceable with objects of a subclass without altering the correctness of the program**. In simpler terms: if S is a subtype of T, then objects of type T may be replaced with objects of type S.

## Why It's Important

### 1. **Polymorphism Reliability**
- Ensures that inheritance hierarchies work correctly
- Guarantees that base class contracts are honored
- Enables safe substitution in polymorphic code

### 2. **Behavioral Consistency**
- Subclasses maintain expected behavior of parent classes
- Prevents surprising behavior when using inheritance
- Maintains logical relationships between types

### 3. **Code Predictability**
- Client code can rely on base class contracts
- No need to check specific types before operations
- Reduces defensive programming needs

### 4. **Design Quality**
- Forces proper inheritance modeling
- Reveals when inheritance isn't the right solution
- Encourages interface-based design

## Code Example Analysis

### ❌ **Bad Example (LSP Violation)**
```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("I'm flying");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("I don't fly");  // 📍 BREAKS CONTRACT
    }
}

// Usage - This will crash! 😱
Bird myBird = new Penguin();
myBird.Fly(); // NotSupportedException thrown!
```

**Problems:**
- **Contract violation**: `Bird.Fly()` should work, but `Penguin.Fly()` throws exception
- **Substitution fails**: Can't safely replace `Bird` with `Penguin`
- **Unexpected behavior**: Client expects flying, gets exception
- **Poor modeling**: Not all birds can fly in real life

### ✅ **Good Example (LSP Compliant)**
```csharp
// Base contract for all birds
public interface IBird
{
    void Eat();
}

// Specialized contract for flying birds
public interface IFlyingBird : IBird
{
    void Fly();
}

// Flying bird implementation
public class Sparrow : IFlyingBird
{
    public void Eat() => Console.WriteLine("I'm eating");
    public void Fly() => Console.WriteLine("I'm flying");
}

// Non-flying bird implementation
public class Penguin : IBird
{
    public void Eat() => Console.WriteLine("I'm eating");
    // No Fly() method - doesn't promise to fly!
}

// Usage - Safe and predictable! ✅
IBird penguin = new Penguin();
penguin.Eat(); // Works perfectly

IFlyingBird sparrow = new Sparrow();
sparrow.Fly(); // Works perfectly
sparrow.Eat(); // Also works
```

**Benefits:**
- **Contracts honored**: Each class fulfills its promises
- **Safe substitution**: Can use any `IBird` for eating, any `IFlyingBird` for flying
- **No surprises**: Methods do what their signatures suggest
- **Better modeling**: Reflects real-world constraints

## Real-World Applications

### Vehicle Hierarchy Example

#### ❌ **LSP Violation**
```csharp
public class Vehicle
{
    public virtual void StartEngine()
    {
        Console.WriteLine("Engine started");
    }
}

public class Bicycle : Vehicle
{
    public override void StartEngine()
    {
        throw new InvalidOperationException("Bicycles don't have engines!");
    }
}

// This breaks when we treat all vehicles the same way
Vehicle[] vehicles = { new Car(), new Bicycle() };
foreach (Vehicle v in vehicles)
{
    v.StartEngine(); // Crashes on Bicycle!
}
```

#### ✅ **LSP Compliant**
```csharp
public interface IVehicle
{
    void Move();
}

public interface IMotorVehicle : IVehicle
{
    void StartEngine();
}

public class Car : IMotorVehicle
{
    public void Move() => Console.WriteLine("Driving");
    public void StartEngine() => Console.WriteLine("Engine started");
}

public class Bicycle : IVehicle
{
    public void Move() => Console.WriteLine("Pedaling");
    // No StartEngine - doesn't promise to have an engine
}

// Safe usage
IVehicle[] vehicles = { new Car(), new Bicycle() };
foreach (IVehicle v in vehicles)
{
    v.Move(); // Works for all vehicles
}
```

### Rectangle/Square Classic Example

#### ❌ **LSP Violation**
```csharp
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    
    public int Area => Width * Height;
}

public class Square : Rectangle
{
    public override int Width
    {
        get => base.Width;
        set { base.Width = base.Height = value; } // 📍 BREAKS EXPECTATION
    }
    
    public override int Height
    {
        get => base.Height;
        set { base.Width = base.Height = value; } // 📍 BREAKS EXPECTATION
    }
}

// This breaks client expectations
Rectangle rect = new Square();
rect.Width = 5;
rect.Height = 3;
Console.WriteLine(rect.Area); // Expected: 15, Actual: 9
```

#### ✅ **LSP Compliant**
```csharp
public interface IShape
{
    int CalculateArea();
}

public class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int CalculateArea() => Width * Height;
}

public class Square : IShape
{
    public int Side { get; set; }
    public int CalculateArea() => Side * Side;
}

// Each shape behaves consistently with its own contract
```

## LSP Guidelines and Rules

### Behavioral Subtyping Rules

1. **Preconditions cannot be strengthened** in subclasses
2. **Postconditions cannot be weakened** in subclasses
3. **Invariants must be preserved** in subclasses
4. **History constraint** - subclass methods shouldn't allow state changes that the base class doesn't allow

### Practical Checks

#### ✅ **LSP Compliant Indicators**
- Subclass can be used wherever base class is expected
- No unexpected exceptions from inherited methods
- Subclass maintains or improves performance characteristics
- All inherited contracts are fulfilled

#### ❌ **LSP Violation Indicators**
- Need to check specific type before calling methods
- Throwing exceptions that base class doesn't throw
- Weakening postconditions (returning less than promised)
- Strengthening preconditions (requiring more than base class)

## Design Strategies for LSP Compliance

### 1. **Favor Composition over Inheritance**
```csharp
// Instead of inheritance that might violate LSP
public class Duck
{
    private IFlyBehavior _flyBehavior;
    private IQuackBehavior _quackBehavior;
    
    public void Fly() => _flyBehavior.Fly();
    public void Quack() => _quackBehavior.Quack();
}
```

### 2. **Use Interfaces for Contracts**
```csharp
public interface IReadable { string Read(); }
public interface IWritable { void Write(string data); }
public interface IReadWritable : IReadable, IWritable { }

// Only implement what you can actually do
public class ReadOnlyFile : IReadable { /* ... */ }
public class WriteOnlyFile : IWritable { /* ... */ }
public class RegularFile : IReadWritable { /* ... */ }
```

### 3. **Abstract Base Classes with Protected Methods**
```csharp
public abstract class DatabaseConnection
{
    public void Connect()
    {
        ValidateConnection();
        EstablishConnection();
        OnConnectionEstablished();
    }
    
    protected abstract void ValidateConnection();
    protected abstract void EstablishConnection();
    protected virtual void OnConnectionEstablished() { }
}
```

## Testing for LSP Compliance

### Substitution Test
```csharp
[Test]
public void AllShapes_ShouldCalculateAreaCorrectly()
{
    IShape[] shapes = { 
        new Rectangle { Width = 5, Height = 3 },
        new Square { Side = 4 },
        new Circle { Radius = 2 }
    };
    
    foreach (IShape shape in shapes)
    {
        int area = shape.CalculateArea();
        Assert.That(area, Is.GreaterThan(0)); // All should work
    }
}
```

## Key Takeaways

1. **Inheritance is about behavior**, not just code reuse
2. **Subclasses must honor base class contracts**
3. **"Is-a" relationship must be behavioral, not just structural**
4. **When in doubt, favor composition or interfaces**
5. **Test substitutability explicitly**

## Common LSP Violations to Avoid

- **Throwing new exceptions** in overridden methods
- **Returning null** when base class returns valid objects
- **Changing side effects** unexpectedly
- **Requiring stronger preconditions** than base class
- **Providing weaker postconditions** than base class

## Benefits of LSP Compliance

| Aspect | Without LSP | With LSP |
|--------|-------------|----------|
| **Code Safety** | Runtime exceptions | Predictable behavior |
| **Polymorphism** | Fragile, needs type checks | Robust, works seamlessly |
| **Testing** | Must test each subtype | Can test through base type |
| **Maintenance** | Defensive programming needed | Clean, straightforward code |
| **Design** | Tight coupling | Loose coupling |

LSP ensures that your inheritance hierarchies are logical, safe, and maintainable - making polymorphism a powerful tool rather than a source of bugs!