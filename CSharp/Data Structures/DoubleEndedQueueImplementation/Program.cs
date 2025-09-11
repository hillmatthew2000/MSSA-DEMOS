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

            System.Console.WriteLine($"Dequeue Rear: {myQueue.DequeueRear()}");
            System.Console.WriteLine($"Dequeue Front: {myQueue.DequeueFront()}");
            myQueue.Display();
            System.Console.WriteLine($"Dequeue Rear: {myQueue.DequeueRear()}");
            System.Console.WriteLine($"Dequeue Front: {myQueue.DequeueFront()}");
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
    private int front, rear, size;

    public DoubleEndedQueue(int capacity)
    {
        deQueueArray = new int[capacity];
        front = -1;
        rear = -1;
        size = capacity;
    }

    public void EnqueueFront(int value)
    {
        //Check if full
        if (front == 0 ? (rear == size - 1) : (front - 1) % size == rear)
        {
            throw new InvalidOperationException("Queue Overflow");
        }
        //Check if empty
        if (front == -1)
        {
            front = 0;
            rear = 0;
        }
        //front first position wrap
        else if (front == 0)
        {
            front = size - 1;
        }
        //decrement front
        else
        {
            front = front - 1;
        }
        deQueueArray[front] = value;
    }

    public void EnqueueRear(int value)
    {
        if ((rear + 1) % size == front)
        {
            throw new InvalidOperationException("Queue Overflow");
        }
        if (front == -1) front = 0;
        rear = (rear + 1) % size;
        deQueueArray[rear] = value;
    }

    public int DequeueFront()
    {
        if (front == -1)
        {
            throw new InvalidOperationException("Queue Underflow");
        }
        int value = deQueueArray[front];
        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        front = (front + 1) % size;
        return value;
    }

    public int DequeueRear()
    {
        if (front == -1)
        {
            throw new InvalidOperationException("Queue Underflow");
        }
        int value = deQueueArray[rear];

        //if one element reset
        if (front == rear) front = -1; rear = -1;

        rear = (rear == 0) ? size - 1 : (rear - 1) % size;
        return value;
    }

    public void Display()
    {
        foreach (int num in deQueueArray)
        {
            System.Console.Write(num + " ");
        }
        System.Console.WriteLine();
    }
}
