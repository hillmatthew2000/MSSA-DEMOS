using System.Text;

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
        //head
        public IntNode? Head { get; private set; }
        //tail
        public IntNode? Tail { get; private set; }

        //count
        int count = 0;

        public SingleLinkedListOfIntegers()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        //Insert Head
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

        //Insert Tail
        public void AddLast(int data)
        {
            //todo: make it work
            IntNode newNode = new IntNode(data);
            if (Tail == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
            }
            Tail = newNode;
            count++;
        }

        //remove head
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            // only one node?
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
            }
            count--;

        }

        //remove tail
        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("The List is empty.Again");
            }
            //only 1
            if (Head?.Next == null)
            {
                Head = null;
                Tail = null;
            }
            //multiple
            else
            {
                //addLast(20), addLast(30), addLast(40)
                //tail should be 30
                //head should be 20
                IntNode current = Head;
                while (current.Next != null && current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            count--;

        }

        //Insert before
        public void AddBefore(int targetData, int newData)
        {
            // test if head is null
            if (Head == null)
            {
                throw new InvalidOperationException("The List is empty. Fired");
            }

            //test if head = target
            if (Head.Data == targetData)
            {
                AddFirst(newData);
            }

            //set current to head
            //traverse list to find the node where targetData is in the next node
            IntNode current = Head;
            while (current.Next != null && current.Next.Data != targetData)
            {
                current = current.Next;
            }
            if (current.Next == null)
            {
                throw new InvalidOperationException("Target data not found. Fired");
            }
            IntNode newNode = new IntNode(newData);
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        //Insert after
        public void AddAfter(int targetData, int newData)
        {

        }

        //remove any node
        public void RemoveNode(int targetData)
        {

        }

        public void RemoveBefore(int targetData)
        {

        }

        public void RemoveAfter(int targetData)
        {

        }


        //what is the size (readonly)
        public int Count => count;

        // public int Count
        // {
        //     get
        //     {
        //         return count;
        //     }
        // }

        public IntNode Find(int targetData)
        {
            //they pass in data to find  (i.e. 7)
            //a) does it exist? (does 7 exist somewhere in the list)
            //b) if not, what to do? (throw an exception or return null?)
            //c) if so , what to do? (return the found node)
            throw new NotImplementedException("Write the find method");
        }


        public string PrintList()
        {
            //use a stringbuilder
            StringBuilder sb = new StringBuilder();

            IntNode? current = Head;
            while (current != null)
            {
                sb.Append(current.Data + " ");
                current = current.Next;
            }

            //return the stringbuilder to string
            return sb.ToString();
        }
    }
}