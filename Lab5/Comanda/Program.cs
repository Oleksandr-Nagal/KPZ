using System;
using System.Collections.Generic;

public abstract class Command
{
    public abstract void Execute();
}

public class HTMLElement
{
    public string TagName { get; set; }
    public List<string> Classes { get; set; } = new List<string>();

    public HTMLElement(string tagName)
    {
        TagName = tagName;
    }

    public void AddClass(string className)
    {
        Classes.Add(className);
    }
}

public class AddClassCommand : Command
{
    private HTMLElement _element;
    private string _className;

    public AddClassCommand(HTMLElement element, string className)
    {
        _element = element;
        _className = className;
    }

    public override void Execute()
    {
        _element.AddClass(_className);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var element = new HTMLElement("p");
        var addClassCommand = new AddClassCommand(element, "highlight");
        addClassCommand.Execute();
        Console.WriteLine(string.Join(", ", element.Classes)); // Output: highlight
    }
}
