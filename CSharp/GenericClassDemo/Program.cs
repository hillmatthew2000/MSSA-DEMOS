namespace GenericClassDemo;

class Program
{
    static void Main(string[] args)
    {
        MyGeneric<int> intGen = new MyGeneric<int>();
        intGen.SetValue(42);
        int result = intGen.GetValue();
        Console.WriteLine($"result is {result}");

        MyGeneric<string> stringGen = new MyGeneric<string>();
        stringGen.SetValue("Hello, Generics!");
        string resultString = stringGen.GetValue();
        Console.WriteLine($"result is {resultString}");
    }
}

public class MyGeneric<T>
{
    private T value;

    public void SetValue(T input)
    {
        value = input;
    }

    public T GetValue()
    {
        return value;
    }
}