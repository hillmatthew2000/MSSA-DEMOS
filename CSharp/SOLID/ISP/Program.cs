namespace ISP;

/* This is a bad example of Interface Segregation Principle (ISP) violation.
The IWorker interface is too broad and forces all implementing classes to provide implementations 
for methods they may not need. */
// class Program
// {
//     static void Main()
//     {
//         IWorker worker = new Robot();
//         worker.Work();
//         worker.Eat();
//     }
// }
// public interface IWorker
// {
//     void Work();
//     void Eat();
// }

// public class Robot : IWorker
// {
//     public void Work() => Console.WriteLine("Robot is working");
//     public void Eat() => throw new NotImplementedException();
// }



/* This is a good example of Interface Segregation Principle (ISP) adherence.
The IWorker interface is split into two smaller, more specific interfaces: IWork and IEat.
This allows classes to implement only the interfaces that are relevant to them. */

class Program
{
    static void Main()
    {
        IWork worker1 = new Robot();
        worker1.Work();

        IWork worker2 = new Human();
        worker2.Work();
        IEat worker2Eating = (IEat)worker2;
        worker2Eating.Eat();

        Human worker3 = new Human();
        worker3.Work();
        worker3.Eat();
    }
}

public interface IWork
{
    void Work();
}
public interface IEat
{
    void Eat();
}
public class Human : IWork, IEat
{
    public void Work()
    {
        Console.WriteLine("Human working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human eating...");
    }
}
public class Robot : IWork
{
    public void Work()
    {
        Console.WriteLine("Robot working...");
    }
}
