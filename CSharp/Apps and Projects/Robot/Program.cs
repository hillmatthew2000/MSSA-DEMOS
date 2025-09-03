using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Robot;

class Program
{
    static void Main(string[] args)
    {
        string model = "C3PO";
        int batteryLevel = 90;
        if (Robot.IsModelAllowed(model))
        {
            Robot jillbot1 = new Robot(model, batteryLevel);
        }
        else
        {
            Console.WriteLine(new ArgumentException("NOT IN MY ROBOT FACTORY"));
        }

        Robot Hillbot = new Robot("R2D2", 19);
        Robot Fillbot = new Robot("RX89A", 40);
        Robot Jillbot = new Robot("C3PO", 90);
        

        Hillbot.ListRobotInfo();
        Fillbot.ListRobotInfo();
        Jillbot.ListRobotInfo();
        

    }


}

// Create a new class Robot
class Robot
{
    // Create some fields of Robot; No intialization needed
    string model;
    int batteryLevel;
    static int totalRobotsActivated;

    public Robot(string model, int batteryLevel)
    {
        this.model = model;
        this.batteryLevel = batteryLevel;
        totalRobotsActivated++;
    }

    // A method that adds an integer to batteryLevel
    public void Recharge(int charged)
    {
        batteryLevel += charged;
        if (batteryLevel >= 100)
        {
            batteryLevel = 100;
        }
        Console.WriteLine(batteryLevel);
    }

    // public static int GetRobotsActivated()
    // {
    //     return totalRobotsActivated;
    // }

    // Create a property to get the total robots activated
    public int TotalRobotsActivated
    {
        get { return totalRobotsActivated; }
    }

    public bool NeedsRecharge()
    {
        return batteryLevel < 20;
    }

    public static bool IsModelAllowed(string model)
    {
        string upperName = model.ToUpper();
        return upperName.StartsWith("RX") && model.Length >= 5;
    }

    public void ListRobotInfo()
    {
        Console.WriteLine($"{model} {batteryLevel}");
    }
}
