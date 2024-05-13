using System;

public class SupportHandler
{
    private SupportHandler nextHandler;

    public SupportHandler SetNextHandler(SupportHandler handler)
    {
        nextHandler = handler;
        return handler;
    }

    public virtual void HandleRequest(string request)
    {
        if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Sorry, we cannot resolve your issue at this level.");
        }
    }
}

public class LevelOneSupport : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "level1")
        {
            Console.WriteLine("Your issue is being resolved at Level One Support.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

public class LevelTwoSupport : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "level2")
        {
            Console.WriteLine("Your issue is being resolved at Level Two Support.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

public class LevelThreeSupport : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "level3")
        {
            Console.WriteLine("Your issue is being resolved at Level Three Support.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}
public class LevelFourSupport : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "level4")
        {
            Console.WriteLine("Your issue is being resolved at Level One Support.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        SupportHandler level1 = new LevelOneSupport();
        SupportHandler level2 = new LevelTwoSupport();
        SupportHandler level3 = new LevelThreeSupport();
        SupportHandler level4 = new LevelFourSupport();
        level1.SetNextHandler(level2).SetNextHandler(level3).SetNextHandler(level4);

        string request = "";

        while (request != "exit")
        {
            Console.WriteLine("Please enter your support request (level1, level2, level3, level4), or 'exit' to quit:");
            request = Console.ReadLine();
            level1.HandleRequest(request);
        }
    }
}
