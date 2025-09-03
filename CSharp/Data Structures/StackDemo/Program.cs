using System.Collections;

namespace StackDemo;

class Program
{
    static void Main()
    {
        Stack pageStack = new Stack();
 
        pageStack.Push("Home");
        pageStack.Push("Products");
        pageStack.Push("Cart");
 
        Console.WriteLine("Current stack (top to bottom:)");
        foreach (var page in pageStack)
        {
            Console.WriteLine(page);
        }
 
        Console.WriteLine($"\nCurrent page (top of stack): {pageStack.Peek()}");
 
        string previousPage = (string)pageStack.Pop();
        Console.WriteLine($"\nBack to: {previousPage}");
 
        Console.WriteLine("Stack after popping");
        foreach (var page in pageStack)
        {
            Console.WriteLine(page);
        }
 
    }
 
}