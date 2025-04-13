namespace BusShuttle;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please select mode (driver or manager): ");
        string mode = Console.ReadLine();
        if(mode == "driver"){
            string command;
            do
            {
                Console.Write("Enter stop name: ");
                string StopName = Console.ReadLine();

                Console.Write("Enter the number of boarded passengers: ");
                int boarded = int.Parse(Console.ReadLine());
                File.AppendAllText("passenger_data.txt", StopName + ": " + boarded + Environment.NewLine);

                Console.Write("Please enter command (end or continue): ");
                command = Console.ReadLine();
            } while(command != "end");
        }
    }
}
