namespace Grid;

class Program
{
    static void Main(string[] args)
    {
 
        int size = 8;
        char firstChar = 'X';
        char secondChar = 'O';
 
        Grid chessBoard = new Grid(size, firstChar, secondChar);
        string string1 = chessBoard.ToString();
        Console.WriteLine(string1);
        Console.WriteLine(chessBoard);
        string string2 = chessBoard.ToBaseString();
        Console.WriteLine(string2);
 
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
 
    public override string ToString()
    {
        string result = "";
 
        //outer for loop (for each row)
        for (int row = 0; row < Size; row++)
        {
            //inner for loop (for each column)
            for (int col = 0; col < Size; col++)
            {
                //check if row value is odd/even
                if ((row + col) % 2 == 0)
                    result += FirstChar; //used to be Console.Write(FirstChar);
                else
                    result += SecondChar; //used to be Console.Write(SecondChar);
            }
            result += "\n"; //used to Console.WriteLine();
        }
        return result;
    }
 
    public string ToBaseString()
    {
        return base.ToString();
    }
 
}