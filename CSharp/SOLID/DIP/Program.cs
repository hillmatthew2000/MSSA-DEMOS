namespace DIP;

/* This is a bad example of Dependency Inversion Principle (DIP).*/
/* In this example, the Client class directly depends on the concrete Service class.
   This violates the Dependency Inversion Principle because high-level modules (Client)
   should not depend on low-level modules (Service); both should depend on abstractions.
   To adhere to DIP, we would introduce an interface that both Client and Service depend on. */

// class Program
// {
//     static void Main(string[] args)
//     {
//         var service = new Service();
//         var client = new Client(service);
//         client.DoSomething();
//     }
// }

// class Service
// {
//     public void Execute()
//     {
//         Console.WriteLine("Service Executed");
//     }
// }

// class Client
// {
//     private readonly Service _service;

//     public Client(Service service)
//     {
//         _service = service;
//     }

//     public void DoSomething()
//     {
//         _service.Execute();
//     }
// }


/* This is a good example of Dependency Inversion Principle (DIP).*/
/* In this improved example, both the ClientGood and ServiceGood classes depend on the IService interface.
   This adheres to the Dependency Inversion Principle because high-level modules (ClientGood) do not depend
   on low-level modules (ServiceGood); both depend on abstractions (IService). */
class Program
{
    static void Main(string[] args)
    {
        IService service = new ServiceGood();
        var client = new ClientGood(service);
        client.DoSomething();
    }
}

interface IService
{
    void Execute();
}

class ServiceGood : IService
{
    public void Execute()
    {
        Console.WriteLine("Service Executed");
    }
}

class ClientGood
{
    private readonly IService _service;

    public ClientGood(IService service)
    {
        _service = service;
    }

    public void DoSomething()
    {
        _service.Execute();
    }
}

