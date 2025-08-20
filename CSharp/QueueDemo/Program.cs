using System.Collections;

namespace QueueDemo;

class Program
{
    static void Main()
    {
        Queue customerQueue = new Queue();

        customerQueue.Enqueue("Alice");
        customerQueue.Enqueue("Bob");
        customerQueue.Enqueue("Charlie");

        Console.WriteLine("Customers in queue:");
        foreach (var customer in customerQueue)
        {
            Console.WriteLine(customer);
        }

        Console.WriteLine($"\nNext in line: {customerQueue.Peek()}");

        string servedCustomer = (string)customerQueue.Dequeue();
        Console.WriteLine($"\nServed customer: {servedCustomer}");

        Console.WriteLine("Queue after serving one customer:");
        foreach (var customer in customerQueue)
        {
            Console.WriteLine(customer);
        }
    }
}
