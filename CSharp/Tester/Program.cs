using System;
using System.Globalization;

class Program
{

    static int[] NextGreaterElement(int[] arr)
    {
        int len = arr.Length;
        int[] nextGreaters = new int[len];

        Stack<int> stack = new Stack<int>();

        for (int i = len - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
            {
                stack.Pop();
            }

            nextGreaters[i] = stack.Count == 0 ? -1 : arr[stack.Peek()];

            stack.Push(i);
        }
        return nextGreaters;
    }

    static void Main(string[] args)
    {
        int[] arr = { 4, 6, 2, 8, 1 };
        int[] nextGreaters = NextGreaterElement(arr);

        for (int i = 0; i < nextGreaters.Length; i++)
        {
            Console.WriteLine($"{arr[i]} -> {nextGreaters[i]}");
        }
    }
}