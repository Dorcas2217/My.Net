using static System.Net.Mime.MediaTypeNames;

class Logger
{
    public delegate void DelegateLogger(string message);
  
    public DelegateLogger RegisteDelegate { get; set; }

    public void LogMessage(string message)
    {
        RegisteDelegate?.Invoke(message);
    }
 
}

class ConsoleLogger 
{
    public void WriteToConsole (string message)
    {
        Console.WriteLine(message);
    }
  
}

class FileLogger
{
    public void WriteToFile (string message)
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        File.WriteAllText(Path.Combine(docPath, "WriteFile.txt"), message);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();
        logger.RegisteDelegate += new ConsoleLogger().WriteToConsole;
        logger.RegisteDelegate += new FileLogger().WriteToFile;
        logger.LogMessage("Hello World!");
    }
}