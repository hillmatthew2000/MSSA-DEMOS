namespace FileStreamDemo
{
    // FileStream Demo in C#
    // This demo shows how to use FileStream to write and read data to/from a file, both with UTF-8 and Unicode encodings.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== FileStream Demo ===\n");

            // --- UTF-8 Example ---
            string utf8Path = "output-utf8.txt";
            string utf8Text = "Hello, FileStream! This is a demo (UTF-8).";
            WriteTextWithEncoding(utf8Path, utf8Text, Encoding.UTF8);
            Console.WriteLine($"[UTF-8] Data written to: {utf8Path}");
            string readUtf8 = ReadTextWithEncoding(utf8Path, Encoding.UTF8);
            Console.WriteLine($"[UTF-8] File Contents: \"{readUtf8}\"\n");

            // --- Unicode Example ---
            string unicodePath = Path.Combine(Path.GetTempPath(), "output-unicode.txt");
            string unicodeText = $"This is the first line{Environment.NewLine}This is the second line (Unicode)";
            WriteTextWithEncoding(unicodePath, unicodeText, Encoding.Unicode);
            Console.WriteLine($"[Unicode] Data written to: {unicodePath}");
            string readUnicode = ReadTextWithEncoding(unicodePath, Encoding.Unicode);
            Console.WriteLine($"[Unicode] File Contents:\n{readUnicode}");
        }

        static void WriteTextWithEncoding(string filePath, string text, Encoding encoding)
        {
            byte[] encodedText = encoding.GetBytes(text);

            using var sourceStream = new FileStream(
                filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: false);

            sourceStream.Write(encodedText, 0, encodedText.Length);
        }

        static string ReadTextWithEncoding(string filePath, Encoding encoding)
        {
            using var sourceStream = new FileStream(
                filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: false);

            byte[] buffer = new byte[sourceStream.Length];
            int bytesRead = sourceStream.Read(buffer, 0, buffer.Length);

            return encoding.GetString(buffer, 0, bytesRead);
        }
    }
}
