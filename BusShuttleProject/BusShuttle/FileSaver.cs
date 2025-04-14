namespace BusShuttle;
using System.IO;
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