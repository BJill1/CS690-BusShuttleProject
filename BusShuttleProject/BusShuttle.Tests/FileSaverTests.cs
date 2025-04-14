namespace BusShuttle.Tests;
using BusShuttle;
public class FileSaverTests
{
    FileSaver filesaver;
    string TestFileName;
    public FileSaverTests()
    {
        TestFileName = "TestFile_doc.txt";
        filesaver = new FileSaver(TestFileName);
    }
    [Fact]
    public void TestFileSaver_Append()
    {
        filesaver.AppendLine("Hello World!");
        var ContentOfFile = File.ReadAllText(TestFileName);
        Assert.Equal("Hello World!"+Environment.NewLine, ContentOfFile);
    }
}