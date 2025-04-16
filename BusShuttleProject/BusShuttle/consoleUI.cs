namespace BusShuttle;
using Spectre.Console;

public class consoleUI
{
    FileSaver filesaver;
    List<Loop> loops;
    List<Stop> stops;
    List<Driver> drivers;

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

        drivers = new List<Driver>();
        drivers.Add(new Driver("Jill"));
        drivers.Add(new Driver("Nathalia"));
        drivers.Add(new Driver("Pauline"));


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

            Driver DriverName = AnsiConsole.Prompt(
                    new SelectionPrompt<Driver>()
                    .Title("Select the driver:")
                    .PageSize(10)
                    .AddChoices(drivers));
            Console.WriteLine("You are now driving as " + DriverName.Name);

            Loop SelectedLoop = AnsiConsole.Prompt(
                    new SelectionPrompt<Loop>()
                    .Title("Select a loop:")
                    .PageSize(10)
                    .AddChoices(loops));
            Console.WriteLine("You selected " + SelectedLoop.Name + " loop.");
            do
            {
                Stop SelectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                    .Title("Select a stop:")
                    .PageSize(10)
                    .AddChoices(SelectedLoop.Stops));
                Console.WriteLine("You selected " + SelectedStop.Name + " stop.");

                int boarded = int.Parse(AskForInput("Enter the number of boarded passengers: "));

                PassengerData Collected_Data = new PassengerData(boarded, SelectedStop, SelectedLoop, DriverName);
                filesaver.AppendData(Collected_Data);
                
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