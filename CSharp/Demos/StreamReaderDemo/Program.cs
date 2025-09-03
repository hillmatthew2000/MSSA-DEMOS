namespace StreamReaderDemo;

class Program
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("TestFile.txt");
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
        reader.Close();
    }
}

    /* StreamReader in C# is a class within the System.IO namespace that is specifically designed
    for reading characters from a stream, such as a text file, in a particular encoding. It is
    commonly used when working with text-based data, as it simplifies reading lines or blocks of text
    efficiently.
    
    Key Features of StreamReader:
    Character Input: Reads characters rather than raw bytes, making it ideal for text files.
    Encoding Support: Supports different character encodings (e.g., UTF-8, ASCII).
    Line-by-Line Reading: Provides methods like ReadLine() to read text line by line.
    Buffering: Efficiently buffers data to improve performance when reading large files.

    Common Methods:
    Read(): Reads the next character or characters from the stream.
    ReadLine(): Reads a single line of text from the stream.
    ReadToEnd(): Reads all characters from the current position to the end of the stream.
    Close(): Closes the StreamReader and releases resources.*/
