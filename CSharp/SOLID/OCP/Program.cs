namespace OCP;

/*This is a good example of Open/Closed Principle because we can add new payment methods
without modifying the existing code. We achieve this by using polymorphism.*/
class Program
{
    static void Main()
    {
        PaymentProcessor processor = new CreditCardProcessor();
        processor.ProcessPayment();

        processor = new PayPalProcessor();
        processor.ProcessPayment();

        processor = new CryptoProcessor();
        processor.ProcessPayment();
    }
}

public abstract class PaymentProcessor
{
    public abstract void ProcessPayment();
}

public class CreditCardProcessor : PaymentProcessor
{
    public override void ProcessPayment() =>
    Console.WriteLine("Processing credit card payment");
}

public class PayPalProcessor : PaymentProcessor
{
    public override void ProcessPayment() =>
    Console.WriteLine("Processing PayPal payment");
}

public class CryptoProcessor : PaymentProcessor
{
    public override void ProcessPayment() =>
    Console.WriteLine("Processing Crypto payment");
}

/*This is a bad example of Open/Closed Principle because we have to modify the PaymentProcessor
class every time we want to add a new payment method.*/

// class Program
// {
//     static void Main()
//     {
//         var processor = new PaymentProcessor();
//         processor.ProcessPayment("PayPal");
//     }
// }
// public class PaymentProcessor
// {
//     public void ProcessPayment(string method)
//     {
//         if (method == "CreditCard")
//             Console.WriteLine("Processing credit card payment");
//         else if (method == "PayPal")
//             Console.WriteLine("Processing PayPal payment");
//         else if (method == "Crypto")
//             Console.WriteLine("Processing Crypto payment");
//     }
// }