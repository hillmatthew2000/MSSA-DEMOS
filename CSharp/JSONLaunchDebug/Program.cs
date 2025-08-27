namespace JSONLaunchDebug;

//Before running this program ensure you move the launch.json file to the root directory
class Program

{

    static void Main()

    {

        string? appMode = Environment.GetEnvironmentVariable("APP_MODE");

        Console.WriteLine("APP_MODE = " + (appMode ?? "not set"));



        if (appMode == "Development")

        {

            Console.WriteLine("Running in development mode: verbose logging enabled.");

        }

        else if (appMode == "Test")

        {

            Console.WriteLine("Running in test mode: using test data.");

        }

        else if (appMode == "Production")

        {

            Console.WriteLine("Running in production mode: normal operations.");

        }

        else

        {

            Console.WriteLine("APP_MODE not recognized: default behavior.");

        }

    }

}