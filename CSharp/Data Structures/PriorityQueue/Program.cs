namespace PriorityQueue;

class Program
{
    static void Main(string[] args)
    {
        PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

        pq.Enqueue("Task 1", 40);
        pq.Enqueue("Task 2", 30);
        pq.Enqueue("Task 3", 20);
        pq.Enqueue("Task 4", 10);
        pq.Enqueue("Task 5", 50);

        while (pq.TryDequeue(out string? item, out int priority))
        {
            Console.WriteLine($"The priority of the programming language {item} is {priority} ");
        }
    }
}
