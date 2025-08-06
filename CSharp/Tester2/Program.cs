using System.Diagnostics;

namespace Tester2;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Hello, World!");
        sb.Replace("World", "C#");
        sb.Remove(5, 1);

        sb.ToString();
    }

}