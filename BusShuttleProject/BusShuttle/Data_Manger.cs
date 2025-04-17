namespace BusShuttle;

public class DataManager
{
    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> passenger_data { get; }
    FileSaver filesaver;

    public DataManager()
    {
        filesaver = new FileSaver("passenger_data.txt");
        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));

        Stops = new List<Stop>();
        var StopsFileContent = File.ReadAllLines("Stops.txt");
        foreach(var stop_name in StopsFileContent){Stops.Add(new Stop(stop_name));}

        Loops[0].Stops.Add(Stops[0]);
        Loops[0].Stops.Add(Stops[1]);
        Loops[0].Stops.Add(Stops[2]);
        Loops[0].Stops.Add(Stops[3]);
        Loops[0].Stops.Add(Stops[4]);
        Loops[0].Stops.Add(Stops[5]);

        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Jill"));
        Drivers.Add(new Driver("Nathalia"));
        Drivers.Add(new Driver("Pauline"));
        passenger_data = new List<PassengerData>();
    }
    public void AddNewPassengerData(PassengerData data)
    {
        this.passenger_data.Add(data);
        this.filesaver.AppendData(data);
    }
}