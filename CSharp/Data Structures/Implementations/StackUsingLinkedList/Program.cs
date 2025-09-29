namespace StackUsingLinkedList;
 
class Program
{
    static void Main(string[] args)
    {
        Stack myStack = new Stack();
 
        myStack.Push(10);
        myStack.Push(20);
        myStack.Push(30);
 
        myStack.Display();
        myStack.Peek();
 
        myStack.Pop();
        myStack.Pop();
 
        myStack.Display();
        myStack.Peek();
 
        myStack.Pop();
        myStack.Display();
 
        myStack.Pop();
 
    }
}
 
class Node
{
    public int Value;
    public Node? Next;
    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}
 
class Stack
{
    private Node? top;
 
    public bool IsEmpty()
    {
        return top == null;
    }
 
    public void Push(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = top;
        top = newNode;
        Console.WriteLine($"Pushed: {value}");
    }
 
    public int Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack Underflow: cannot pop from an empty stack");
        int poppedValue = top!.Value;
        top = top.Next;
        Console.WriteLine($"Popped: {poppedValue}");
        return poppedValue;
    }
 
    public int Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty: cannot peek");
        Console.WriteLine($"Peeked: {top!.Value}");
        return top.Value;
    }
 
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }
        Console.WriteLine("Stack contents (top to bottom)");
        Node? current = top;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
}