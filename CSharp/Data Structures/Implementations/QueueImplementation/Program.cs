namespace QueueImplementation;

class Program
{
    static void Main()
    {
        Queue myQueue = new Queue();
        myQueue.Enqueue(10);
        myQueue.Enqueue(20);
        myQueue.Enqueue(30);
        myQueue.Enqueue(40);
        myQueue.Enqueue(50);

        myQueue.Display();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(myQueue.Dequeue());
        }


    }
}

public class Queue
{
    private Node? front;
    private Node? rear;

    public Queue()
    {
        front = null;
        rear = null;
    }

    public bool IsEmpty() => front == null;

    public void Enqueue(int value)
    {
        Node newNode = new Node(value);
        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
    }

    public int Dequeue()
    {
        if (front == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        int dequeuedValue = front.Value;
        front = front.Next;

        if (front == null)
        {
            rear = null;
        }

        return dequeuedValue;
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        Node? current = front;
        while (current != null)
        {
            Console.Write(current.Value + ", ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Node
{
    public int Value;
    public Node? Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}