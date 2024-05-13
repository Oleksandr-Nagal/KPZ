using System;
using System.IO;
using System.Text.RegularExpressions;

public interface ITextReader
{
    string[,] ReadTextFile(string filePath);
}

public class SmartTextReader : ITextReader
{
    public string[,] ReadTextFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int maxLength = lines.Length > 0 ? lines[0].Length : 0;
        string[,] result = new string[lines.Length, maxLength];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                result[i, j] = lines[i][j].ToString();
            }
        }
        return result;
    }
}

public class SmartTextChecker : ITextReader
{
    private readonly ITextReader _reader;

    public SmartTextChecker(ITextReader reader)
    {
        _reader = reader;
    }

    public string[,] ReadTextFile(string filePath)
    {
        Console.WriteLine($"Opening file: {filePath}");
        string[,] result = _reader.ReadTextFile(filePath);
        Console.WriteLine($"Successfully read file: {filePath}");
        Console.WriteLine($"Number of lines: {result.GetLength(0)}");
        Console.WriteLine($"Number of characters: {result.Length}");
        Console.WriteLine($"Closing file: {filePath}");
        return result;
    }
}

public class SmartTextReaderLocker : ITextReader
{
    private readonly ITextReader _reader;
    private readonly Regex _regex;

    public SmartTextReaderLocker(ITextReader reader, string pattern)
    {
        _reader = reader;
        _regex = new Regex(pattern);
    }

    public string[,] ReadTextFile(string filePath)
    {
        if (_regex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return null;
        }
        return _reader.ReadTextFile(filePath);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ITextReader textReader = new SmartTextReader();
        ITextReader smartReaderWithLogging = new SmartTextChecker(textReader);
        string[,] fileContent = smartReaderWithLogging.ReadTextFile("example.txt");

        ITextReader smartReaderWithLock = new SmartTextReaderLocker(textReader, "restricted.*");
        string[,] restrictedContent = smartReaderWithLock.ReadTextFile("restricted_file.txt");
    }
}
