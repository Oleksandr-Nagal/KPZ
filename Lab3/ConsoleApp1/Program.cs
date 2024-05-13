using System;

public interface ILogger
{
    void Log(string message);
    void Error(string message);
    void Warn(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Log: {message}");
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }

    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Warning: {message}");
        Console.ResetColor();
    }
}

public interface IFileWriter
{
    void Write(string text);
    void WriteLine(string text);
}

public class FileWriter : IFileWriter
{
    public void Write(string text)
    {
        Console.WriteLine($"Writing to file: {text}");
    }

    public void WriteLine(string text)
    {
        Console.WriteLine($"Writing line to file: {text}");
    }
}

public class FileLoggerAdapter : ILogger
{
    private readonly IFileWriter _fileWriter;

    public FileLoggerAdapter(IFileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public void Log(string message)
    {
        _fileWriter.WriteLine($"Log: {message}");
    }

    public void Error(string message)
    {
        _fileWriter.WriteLine($"Error: {message}");
    }

    public void Warn(string message)
    {
        _fileWriter.WriteLine($"Warning: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new Logger();
        logger.Log("This is a log message");
        logger.Error("This is an error message");
        logger.Warn("This is a warning message");

        Console.WriteLine();

        IFileWriter fileWriter = new FileWriter();
        ILogger fileLogger = new FileLoggerAdapter(fileWriter);
        fileLogger.Log("This is a log message for file");
        fileLogger.Error("This is an error message for file");
        fileLogger.Warn("This is a warning message for file");
    }
}
