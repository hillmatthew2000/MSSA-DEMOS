using System.Text;

namespace StreamWriterDemo;

class Program
{
    public static void Main(string[] args)
    {
        // Create a temp file path
        string path = Path.Combine(Path.GetTempPath(), "sync-stream.txt");

        // Prepare sample text
        string fullText = $"This is the first line{Environment.NewLine}This is the second line";

        // Write the full text to the file
        WriteFullText(path, fullText);

        // Read and display the full text from the file
        ReadFullText(path);

        // Overwrite file with new lines using WriteLine
        WriteLines(path);

        // Read and display the file line by line
        ReadLines(path);
    }

    static void WriteFullText(string filePath, string text)
    {
        // Create StreamWriter with Unicode encoding
        using var writer = new StreamWriter(filePath, false, Encoding.Unicode);

        // Write the entire text to the file
        writer.Write(text);
    }

    static void ReadFullText(string filePath)
    {
        // Create StreamReader with Unicode encoding
        using var reader = new StreamReader(filePath, Encoding.Unicode);

        // Read the entire file content
        string content = reader.ReadToEnd();

        // Print label
        Console.WriteLine("Full text");

        // Print file content
        Console.WriteLine(content);
    }

    static void WriteLines(string filePath)
    {
        // Create StreamWriter with Unicode encoding
        using var writer = new StreamWriter(filePath, false, Encoding.Unicode);

        // Write first line
        writer.WriteLine("Line 1");

        // Write second line
        writer.WriteLine("Line 2");
    }

    static void ReadLines(string filePath)
    {
        // Create StreamReader with Unicode encoding
        using var reader = new StreamReader(filePath, Encoding.Unicode);

        string line;

        // Print label
        Console.WriteLine("Line by line");

        // Read each line until end of file
        while ((line = reader.ReadLine()) != null)
        {
            // Print each line
            Console.WriteLine(line);
        }
    }
}
