namespace BusShuttle.Tests;
using BusShuttle;
public class FileSaverTests
{
    FileSaver filesaver;
    string TestFileName;
    public FileSaverTests()
    {
        TestFileName = "TestFile_doc.txt";
        File.Delete(TestFileName);
        filesaver = new FileSaver(TestFileName);
    }
    [Fact]
    public void TestFileSaver_Append()
    {
        filesaver.AppendLine("Hello World!");
        var ContentOfFile = File.ReadAllText(TestFileName);
        Assert.Equal("Hello World!"+Environment.NewLine, ContentOfFile);
    }
    [Fact]
    public void TestFileSaver_AppendData()
    {
        Stop SampleStop = new Stop("My stop");
        Loop SampleLoop = new Loop("My loop");
        Driver SampleDriver = new Driver("Sample");
        PassengerData SampleData = new PassengerData(5, SampleStop, SampleLoop, SampleDriver);
        filesaver.AppendData(SampleData);
        var ContentOfFile = File.ReadAllText(TestFileName);
        Assert.Equal("Sample : My loop : My stop : 5"+Environment.NewLine, ContentOfFile);
    }
}