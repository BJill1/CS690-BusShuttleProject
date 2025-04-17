namespace BusShuttle;
using System.IO;
public class FileSaver
{
    string FileName;
    public FileSaver(string FileName)
    {
        this.FileName = FileName;
        if(!File.Exists(this.FileName)){
            File.Create(this.FileName).Close();
        }
        
    }
    public void AppendLine(string line)
    {
        File.AppendAllText(this.FileName, line+Environment.NewLine);
    }
    public void AppendData(PassengerData data){
        File.AppendAllText(this.FileName, data.Driver + " : " + data.Loop + " : " + data.Stop + " : " + data.Boarded + Environment.NewLine);
    }
}