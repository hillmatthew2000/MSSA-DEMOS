namespace EnumDemo;

class Program
{
    static void Main()
    {
        OrderStatus currentStatus = OrderStatus.Processing;

        Console.WriteLine("Current order status " + currentStatus);

        currentStatus = OrderStatus.Shipped;

        switch (currentStatus)
        {
            case OrderStatus.Pending:
                Console.WriteLine("Order has not been processed yet");
                break;
            case OrderStatus.Processing:
                Console.WriteLine("Order is being processed");
                break;
            case OrderStatus.Shipped:
                Console.WriteLine("Order has been shipped");
                break;
            case OrderStatus.Delivered:
                Console.WriteLine("Order has been delivered");
                break;
            case OrderStatus.Cancelled:
                Console.WriteLine("Order has been cancelled");
                break;
        }
    }

}

enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}