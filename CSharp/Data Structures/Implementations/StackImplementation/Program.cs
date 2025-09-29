namespace StackImplementation;

class Program
{
    static void Main()
    {
        Mystack myArrStack = new Mystack(5);

        myArrStack.Push(0);
        myArrStack.Push(1);
        myArrStack.Push(2);
        myArrStack.Push(3);
        myArrStack.Push(4);

        myArrStack.DisplayStack();

        try
        {
            myArrStack.Push(5); // should throw an exception
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Popped value: " + myArrStack.Pop());
        Console.WriteLine("Top value: " + myArrStack.Peek());
    }

    public class Mystack
    {
        private int[] stackArray;
        private int topOfStack;

        public Mystack(int size)
        {
            stackArray = new int[size];
            topOfStack = -1;
        }

        //method that acts as push: adds new element to the "top" of the array
        public void Push(int value)
        {
            if (topOfStack >= stackArray.Length - 1)
            {
                throw new InvalidOperationException("Stack overflow: cannot push to a full stack.");
            }
            stackArray[++topOfStack] = value;
        }

        //method that acts as pop: removes an element from the "top" of the array
        public int Pop()
        {
            if (topOfStack == -1)
            {
                throw new InvalidOperationException("Stack underflow: cannot pop from an empty stack.");
            }
            return stackArray[topOfStack--];
        }

        //method that acts as peek: allows you to access without removing the "top" element of the array
        public int Peek()
        {
            if (topOfStack == -1)
            {
                throw new InvalidOperationException("Stack is empty: cannot peek.");
            }
            return stackArray[topOfStack];
        }

        //method that displays the stack
        public void DisplayStack()
        {
            for (int i = topOfStack; i >= 0; i--)
            {
                Console.WriteLine(stackArray[i]);
            }
        }

    }
    
}
