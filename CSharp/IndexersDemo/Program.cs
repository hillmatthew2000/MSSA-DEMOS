using System.Collections;

namespace IndexerDemo;

class Program
{
    static void Main(string[] args)
    {
        Library myLibrary = new Library();
        myLibrary.AddBook(new Book("Catch-22", "Joseph Heller"));
        myLibrary.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
        myLibrary.AddBook(new Book("1984", "George Orwell"));

        Console.WriteLine("First book: " + myLibrary[0]);
        Console.WriteLine("Second book: " + myLibrary[1]);
        Console.WriteLine("Third book: " + myLibrary[2]);

        myLibrary[2] = new Book("Moby Dick", "Herman Melville");
        Console.WriteLine("Updated third book: " + myLibrary[2]);

        Console.WriteLine("Find by title 'Catch-22: " + myLibrary["Catch-22"]);

        //enumerate the content of the collection
        for (int i = 0; i < myLibrary.Count; i++)
        {
            Console.WriteLine($"Book {i + 1}: {myLibrary[i]}");
        }
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}
class Library : IEnumerable// Implement generic IEnumerable
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    //String based indexer
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

    //Int based indexer
    public Book this[int index]
    {
        get => books[index];
        set => books[index] = value;
    }

    public int Count => books.Count;

    //Enumerator Support
    public IEnumerator<Book> GetEnumerator()
    {
        return books.GetEnumerator();
    }

    //non generic enumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}


public class BaseballTeam
    {
        private string[] players = new string[9];
        private readonly List<string> positionAbbreviations = new List<string>
        {
            "P", "C", "1B", "2B", "3B", "SS", "LF", "CF", "RF"
        };
 
        public string this[int position]
        {
            get { return players[position - 1]; }
            set { players[position - 1] = value; }
        }
 
        public string this[string position]
        {
            get { return players[positionAbbreviations.IndexOf(position)]; }
            set { players[positionAbbreviations.IndexOf(position)] = value; }
        }
 
    }