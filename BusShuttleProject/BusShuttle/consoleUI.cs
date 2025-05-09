namespace BusShuttle;
using Spectre.Console;

public class consoleUI
{
    DataManager data_manager;

    public consoleUI()
    {
        data_manager = new DataManager();
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
        if(mode == "driver")
        {

            string command;

            Driver DriverName = AnsiConsole.Prompt(
                    new SelectionPrompt<Driver>()
                    .Title("Select the driver:")
                    .PageSize(10)
                    .AddChoices(data_manager.Drivers));
            Console.WriteLine("You are now driving as " + DriverName.Name);

            Loop SelectedLoop = AnsiConsole.Prompt(
                    new SelectionPrompt<Loop>()
                    .Title("Select a loop:")
                    .PageSize(10)
                    .AddChoices(data_manager.Loops));
            Console.WriteLine("You selected " + SelectedLoop.Name + " loop.");
            do
            {
                Stop SelectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                    .Title("Select a stop:")
                    .PageSize(10)
                    .AddChoices(SelectedLoop.Stops));
                Console.WriteLine("You selected " + SelectedStop.Name + " stop.");

                int boarded = AnsiConsole.Prompt(
                                new TextPrompt<int>("Enter the number of boarded passengers: "));

                PassengerData Collected_Data = new PassengerData(boarded, SelectedStop, SelectedLoop, DriverName);
                
                
                data_manager.AddNewPassengerData(Collected_Data);
                
                    command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please enter command (end or continue): ")
                    .PageSize(10)
                    .AddChoices(new[]{
                    "end", "continue"
                }));

            } while(command != "end");
        }
        
        if(mode == "manager")
        {
            string command;
            do{
                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("What do you want to do")
                    .PageSize(10)
                    .AddChoices(new[]{
                    "add stop", "delete stop", "list stops", "end"
                }));
                if(command == "add stop"){
                    var NewStopName = AnsiConsole.Prompt(new TextPrompt<string>("Enter new stop name: "));
                    data_manager.AddStop(new Stop(NewStopName));
 
                }
                else if(command == "delete stop"){
                    Stop StopToDelete = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                    .Title("Select a stop to delete:")
                    .PageSize(10)
                    .AddChoices(data_manager.Stops));
                    Console.WriteLine("You want to delete the " + data_manager.Stops);
                    data_manager.RemoveStop(StopToDelete);
                }
                else if(command == "list stops"){
                    var table = new Table();
                    table.AddColumn("Stop Name");
                    foreach(var stop in data_manager.Stops){
                        table.AddRow(stop.Name);
                    }
                    AnsiConsole.Write(table);
                }
            } while(command != "end");
        }
    }

}