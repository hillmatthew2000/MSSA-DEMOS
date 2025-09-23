namespace LSP;

/* This is a good example of Liskov Substitution Principle (LSP) adherence.
   The Penguin class does not inherit from Bird, thus avoiding the violation. */

class Program
{
    static void Main()
    {
        IFlyingBird sparrow = new Sparrow();
        sparrow.Fly();
    }
}
public interface IBird
{
    void Eat();
}
 
public interface IFlyingBird : IBird
{
    void Fly();
}
 
public class Sparrow : IFlyingBird
{
    public void Eat() => Console.WriteLine("I'm eating");
    public void Fly() => Console.WriteLine("I'm flying");
}
 
public class Penguin : IBird
{
    public void Eat() => Console.WriteLine("I'm eating");
}

/* This is a bad example of Liskov Substitution Principle (LSP) violation.
   The Penguin class cannot substitute the Bird class without altering the expected behavior. */
// class Program
// {
//     static void Main()
//     {
//         Bird myBird = new Penguin();
//         myBird.Fly();
// }
// }
// public class Bird
// {
//     public virtual void Fly()
//     {
//         Console.WriteLine("I'm flying");
//     }
// }

//     public class Penguin : Bird
//     {
//         public override void Fly()
//         {
//             throw new NotSupportedException("I don't fly");
//         }
//     }
 