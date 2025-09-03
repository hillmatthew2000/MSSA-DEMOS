using System.Collections;

namespace IndexerDemo;

class Program
{
    static void Main(string[] args)
    {
        // Create and populate the library
        Library myLibrary = new Library();
        myLibrary.AddBook(new Book("Catch-22", "Joseph Heller"));
        myLibrary.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
        myLibrary.AddBook(new Book("1984", "George Orwell"));

        // Access books by integer index
        Console.WriteLine("First book: " + myLibrary[0]);
        Console.WriteLine("Second book: " + myLibrary[1]);
        Console.WriteLine("Third book: " + myLibrary[2]);

        // Update a book using integer indexer
        myLibrary[2] = new Book("Moby Dick", "Herman Melville");
        Console.WriteLine("Updated third book: " + myLibrary[2]);

        // Access book by title using string indexer
        Console.WriteLine("Find by title 'Catch-22: " + myLibrary["Catch-22"]);

        // Enumerate library using foreach
        foreach (var book in myLibrary)
        {
            Console.WriteLine(book);
        }

        // Enumerate library using explicit enumerator
        Console.WriteLine("All books in the library");
        IEnumerator<Book> enumerator = myLibrary.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Book current = enumerator.Current;
            Console.WriteLine(current);
        }
    }
}

// Represents a book with title and author
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    // String representation of a book
    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}

// Library collection with indexers and enumeration support
class Library : IEnumerable<Book> // Implement generic IEnumerable
{
    private List<Book> books = new List<Book>();

    // Add a book to the library
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // String-based indexer to find book by title
    public Book this[string title]
    {
        get
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return book;
            }
            return null;
        }
    }

    // Integer-based indexer to access book by position
    public Book this[int index]
    {
        get => books[index];
        set => books[index] = value;
    }

    // Number of books in the library
    public int Count => books.Count;

    // Generic enumerator for foreach support
    public IEnumerator<Book> GetEnumerator()
    {
        return books.GetEnumerator();
    }

    // Non-generic enumerator implementation
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Baseball team with indexers for position and abbreviation
public class BaseballTeam
{
    private string[] players = new string[9];
    private readonly List<string> positionAbbreviations = new List<string>
    {
        "P", "C", "1B", "2B", "3B", "SS", "LF", "CF", "RF"
    };

    // Integer-based indexer for player position
    public string this[int position]
    {
        get { return players[position - 1]; }
        set { players[position - 1] = value; }
    }

    // String-based indexer for position abbreviation
    public string this[string position]
    {
        get { return players[positionAbbreviations.IndexOf(position)]; }
        set { players[positionAbbreviations.IndexOf(position)] = value; }
    }
}