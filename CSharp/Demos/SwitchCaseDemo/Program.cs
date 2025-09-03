using System.Buffers;
using System.Net;
using System.Threading.Channels;

namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        // SKU = Stock Keeping Unit.
        // SKU value format: <product #>-<2-letter color code>-<size code>
        string Sku = "01-MN-L";

        string[] product = Sku.Split('-');

        string type = "";
        string color = "";
        string size = "";

        switch (product[0])
        {
            case "01":
                type = "Sweat shirt";
                break;
            case "02":
                type = "T-Shirt";
                break;
            case "03":
                type = "Sweat pants";
                break;
            default:
                type = "Other";
                break;
        }

        switch (product[1])
        {
            case "MN":
                color = "Mint";
                break;
            case "RD":
                color = "Red";
                break;
            case "BL":
                color = "Blue";
                break;
            default:
                color = "Other";
                break;
        }

        switch (product[2])
        {
            case "S":
                size = "Small";
                break;
            case "M":
                size = "Medium";
                break;
            case "L":
                size = "Large";
                break;
            default:
                size = "One Size Fits All";
                break;
        }

        Console.WriteLine($"Product: {size} {color} {type}");

    }

}