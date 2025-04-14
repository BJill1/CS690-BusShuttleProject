namespace BusShuttle;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        FileSaver filesaver = new FileSaver("passenger_data.txt");
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
public class FileSaver
{
    string FileName;
    public FileSaver(string FileName)
    {
        this.FileName = FileName;
        File.Create(this.FileName).Close();
    }
    public void AppendLine(string line)
    {
        File.AppendAllText(this.FileName, line+Environment.NewLine);
    }
    

}