namespace BusShuttle;

public class consoleUI
{
    FileSaver filesaver;
    public consoleUI()
    {
        filesaver = new FileSaver("passenger_data.txt");
    }
    public void show()
    {
        string mode = AskForInput("Please select mode (driver or manager): ");
        if(mode == "driver"){
            string command;
            do
            {
                string StopName = AskForInput("Enter stop name: ");

                int boarded = int.Parse(AskForInput("Enter the number of boarded passengers: "));
                filesaver.AppendLine(StopName + ": " + boarded);
                
                command = AskForInput("Please enter command (end or continue): ");
            } while(command != "end");
        }
    }
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}