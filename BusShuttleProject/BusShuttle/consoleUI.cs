namespace BusShuttle;
using Spectre.Console;

public class consoleUI
{
    FileSaver filesaver;
    List<Loop> loops;
    List<Stop> stops;

    public consoleUI()
    {
        filesaver = new FileSaver("passenger_data.txt");
        loops = new List<Loop>();
        loops.Add(new Loop("Red"));
        loops.Add(new Loop("Green"));
        loops.Add(new Loop("Blue"));

        stops = new List<Stop>();
        stops.Add(new Stop("Music"));
        stops.Add(new Stop("Tower"));
        stops.Add(new Stop("Oakwood"));
        stops.Add(new Stop("Anthony"));
        stops.Add(new Stop("Letterman"));

        loops[0].Stops.Add(stops[0]);
        loops[0].Stops.Add(stops[1]);
        loops[0].Stops.Add(stops[2]);
        loops[0].Stops.Add(stops[3]);
        loops[0].Stops.Add(stops[4]);

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
            Loop SelectedLoop = AnsiConsole.Prompt(
                    new SelectionPrompt<Loop>()
                    .Title("Select a loop:")
                    .PageSize(10)
                    .AddChoices(loops));
            do
            {
                Stop SelectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                    .Title("Select a stop:")
                    .PageSize(10)
                    .AddChoices(SelectedLoop.Stops));

                int boarded = int.Parse(AskForInput("Enter the number of boarded passengers: "));
                filesaver.AppendLine(SelectedStop.Name + ": " + boarded);
                
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