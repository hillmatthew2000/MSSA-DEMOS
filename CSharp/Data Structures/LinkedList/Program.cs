namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        //create a linked list
        SingleLinkedListOfIntegers list = new SingleLinkedListOfIntegers();
        //show the count
        Console.WriteLine("Count: " + list.Count);

        //use the method addfirst to add the number 12
        list.AddFirst(12);
        list.AddFirst(7);

        //use the method printlist to print the list
        list.PrintList();
    }

    public class IntNode
    {
        public int Data { get; set; }
        public IntNode? Next { get; set; }

        public IntNode()
        {
            Data = default;
            Next = null;
        }

        public IntNode(int data)
        {
            Data = data;
            Next = null;
        }


        public IntNode(int data, IntNode next)
        {
            Data = data;
            Next = next;
        }
    }

    public class SingleLinkedListOfIntegers
    {
        IntNode Head;
        IntNode Tail;
        int count = 0;

        public SingleLinkedListOfIntegers()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public int Count => count;

        public void AddFirst(int data)
        {
            IntNode newNode = new IntNode(data);
            if (Head == null)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
            }
            Head = newNode;
            count++;
        }

        public void AddLast(int data)
        {
            IntNode newNode = new IntNode(data);
            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
            Tail.Next = newNode;
            Tail = newNode;
            }
            count++;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            //check for one node
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
                count--;
                return;
            }
            count--;
        }

        public void RemoveLast()
        {
            if (Head == null) return;
            if (Head.Next == null)
            {
                Head = null;
                return;
            }

            IntNode current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        public void AddAfter(IntNode target, int data)
        {
            IntNode newNode = new IntNode(data);
            newNode.Next = target.Next;
            target.Next = newNode;
        }

        public void AddAfter(int target, int data)
        {
            IntNode? current = Head;
            while (current != null)
            {
                if (current.Data == target)
                {
                    AddAfter(current, data);
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveNode(int targetData)
        {
            if (Head == null) return;
            if (Head.Data == targetData)
            {
                Head = Head.Next;
                return;
            }

            IntNode? current = Head;
            while (current.Next != null)
            {
                if (current.Next.Data == targetData)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        public IntNode Find(int targetData)
        {
            IntNode? current = Head;
            while (current != null)
            {
                if (current.Data == targetData)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void PrintList()
        {
            IntNode? current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
