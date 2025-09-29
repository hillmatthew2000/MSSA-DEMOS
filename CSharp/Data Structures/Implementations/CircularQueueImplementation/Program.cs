using System.Globalization;

namespace CircularQueueImplementation;

class Program
{
    static void Main()
    {
        MyCircularQueue myQueue = new MyCircularQueue(5);
        myQueue.Enqueue(10);
        myQueue.Enqueue(20);
        myQueue.Enqueue(30);
        myQueue.Enqueue(40);
        myQueue.DisplayQueue();
        Console.WriteLine("\nDequeued: " + myQueue.Dequeue());
        myQueue.DisplayQueue();
    }
}

class MyCircularQueue
{
    private int[] queueArray;
    private int front, rear, size;

    public MyCircularQueue(int capacity)
    {
        queueArray = new int[capacity];
        front = -1;
        rear = -1;
        size = capacity;
    }

    //method to enqueue
    public void Enqueue(int value)
    {
        if ((rear + 1) % size == front)
        {
            Console.WriteLine("Queue Overflow");
            return;
        }
        if (front == -1) front = 0;
        rear = (rear + 1) % size;
        queueArray[rear] = value;
    }

    //mehtod to dequeue: removes front the front
    public int Dequeue()
    {
        if (front == -1)
        {
            throw new InvalidOperationException("Queue Underflow");
        }
        int temp = queueArray[front];
        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else front = (front + 1) % size;
        return temp;
    }

    //method to display queue
    public void DisplayQueue()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        int i = front;
        do
        {
            Console.Write(queueArray[i] + " ");
            i = (i + 1) % size;
        } while (i != (rear + 1) % size);
    }



}
