namespace EventHandlerDemo;

class Program
{
    static void Main(string[] args)
    {
        Stock stock = new Stock("MSFT");

        //Subscriber1: log to console
        stock.PriceChanged += (oldPrice, newPrice) =>
        {
            Console.WriteLine($"Price changed from {oldPrice:C} to {newPrice:C}");
        };

        //Subscriber2: alert if price drops
        stock.PriceChanged += (oldPrice, newPrice) =>
        {
            if (newPrice < oldPrice)
            {
                Console.WriteLine($"Alert: Price has dropped");
            }
        };

        stock.Price = 400m;
        stock.Price = 300m;
        stock.Price = 250m;
        stock.Price = 1000m;

    }
}

public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);
public class Stock
{
    string symbol;
    decimal price;
    public Stock(string symbol) => this.symbol = symbol;
    public event PriceChangedHandler PriceChanged;
    public decimal Price
    {
        get => price;
        set
        {
            if (price == value) return;
            decimal oldPrice = price;
            price = value;

            if (PriceChanged != null)
            {
                PriceChanged(oldPrice, price);
            }
        }
    }
}
