namespace Grid;

class Program
{
    static void Main(string[] args)
    {

        int size = 8;
        char firstChar = 'X';
        char secondChar = 'O';

        Grid chessBoard = new Grid(size, firstChar, secondChar);
        chessBoard.Display();
        chessBoard.Size = 10;
        chessBoard.Display();

    }
}

class Grid
{
    public int Size { get; set; }
    public char FirstChar { get; set; }
    public char SecondChar { get; set; }

    public Grid(int size, char firstChar, char secondChar)
    {
        Size = size;
        FirstChar = firstChar;
        SecondChar = secondChar;
    }

    public void Display()
    {
        //outer for loop (for each row)
        for (int row = 0; row < Size; row++)
        {
            //inner for loop (for each column)
            for (int col = 0; col < Size; col++)
            {
                //check if row value is odd/even
                if ((row + col) % 2 == 0)
                    Console.Write(FirstChar);
                else
                    Console.Write(SecondChar);
            }
            Console.WriteLine();
        }
    }

}