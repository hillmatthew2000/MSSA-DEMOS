namespace DoubleEndedQueueImplementation;

class Program
{
    static void Main(string[] args)
    {
        DoubleEndedQueue myQueue = new DoubleEndedQueue(5);
        try
        {
            myQueue.EnqueueFront(1);
            myQueue.EnqueueFront(2);
            myQueue.Display();

            myQueue.EnqueueRear(3);
            myQueue.EnqueueRear(4);
            myQueue.Display();

            Console.WriteLine($"Dequeue Rear: {myQueue.DequeueRear()}");
            Console.WriteLine($"Dequeue Front: {myQueue.DequeueFront()}");
            myQueue.Display();
            Console.WriteLine($"Dequeue Rear: {myQueue.DequeueRear()}");
            Console.WriteLine($"Dequeue Front: {myQueue.DequeueFront()}");
            myQueue.Display();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class DoubleEndedQueue
{
    private int[] deQueueArray;
    private int front, rear, size, capacity;

    public DoubleEndedQueue(int capacity)
    {
        this.capacity = capacity;
        deQueueArray = new int[capacity];
        front = -1;
        rear = -1;
        size = 0;
    }

    public bool IsFull() => size == capacity;
    public bool IsEmpty() => size == 0;

    public void EnqueueFront(int value)
    {
        //Check if full
        if (IsFull())
        {
            throw new InvalidOperationException("Queue Overflow");
        }
        //Check if empty
        if (IsEmpty())
        {
            front = 0;
            rear = 0;
        }
        else
        {
            front = (front - 1 + capacity) % capacity;
        }
        deQueueArray[front] = value;
        size++;
    }

    public void EnqueueRear(int value)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Queue Overflow");
        }
        if (IsEmpty()) front = 0;
        else
            rear = (rear + 1) % capacity;
        deQueueArray[rear] = value;
        size++;
    }

    public int DequeueFront()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue Underflow");
        }
        int value = deQueueArray[front];
        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else
            front = (front + 1) % capacity;
        size--;
        return value;
    }

    public int DequeueRear()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue Underflow");
        }
        int value = deQueueArray[rear];

        //if one element reset
        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else
        {
            rear = (rear - 1 + capacity) % capacity;
        }
        size--;
        return value;
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        foreach (int num in deQueueArray)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
