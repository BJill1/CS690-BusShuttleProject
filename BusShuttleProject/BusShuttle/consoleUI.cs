namespace BusShuttle;
using Spectre.Console;

public class consoleUI
{
    FileSaver filesaver;
    public consoleUI()
    {
        filesaver = new FileSaver("passenger_data.txt");
    }
    public void show()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select mode (driver or manager): ")
            .PageSize(10)
            .AddChoices(new[]{
                "driver", "manager"
        }));
        if(mode == "driver"){
            string command;
            do
            {
                string StopName = AskForInput("Enter stop name: ");

                int boarded = int.Parse(AskForInput("Enter the number of boarded passengers: "));
                filesaver.AppendLine(StopName + ": " + boarded);
                
                    command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please enter command (end or continue): ")
                    .PageSize(10)
                    .AddChoices(new[]{
                    "end", "continue"
                }));
            } while(command != "end");
        }
    }
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}