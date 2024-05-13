using System;

public interface IImageStrategy
{
    void LoadImage(string url);
}

public class FileSystemImageStrategy : IImageStrategy
{
    public void LoadImage(string url)
    {
        Console.WriteLine($"Loading image from file system: {url}");
    }
}

public class NetworkImageStrategy : IImageStrategy
{
    public void LoadImage(string url)
    {
        Console.WriteLine($"Loading image from network: {url}");
    }
}

public class Image
{
    private readonly string _url;
    private readonly IImageStrategy _strategy;

    public Image(string url, IImageStrategy strategy)
    {
        _url = url;
        _strategy = strategy;
    }

    public void Load()
    {
        _strategy.LoadImage(_url);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Image fileSystemImage = new Image("path/to/image.jpg", new FileSystemImageStrategy());
        fileSystemImage.Load();

        Image networkImage = new Image("http://example.com/image.jpg", new NetworkImageStrategy());
        networkImage.Load();
    }
}
