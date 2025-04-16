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
        if(mode == "driver"){

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
    }
    //public static string AskForInput(string message)
    //{
      //  Console.Write(message);
       // return Console.ReadLine();
   // }
}