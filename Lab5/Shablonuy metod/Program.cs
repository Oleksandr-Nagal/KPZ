using System;

public abstract class CustomElement
{
    public CustomElement()
    {
        OnCreated();
    }

    public void Insert()
    {
        OnInserted();
    }

    public void Remove()
    {
        OnRemoved();
    }

    protected virtual void OnCreated() { }
    protected virtual void OnInserted() { }
    protected virtual void OnRemoved() { }
}

public class HTMLElement : CustomElement
{
    public string TagName { get; set; }

    public HTMLElement(string tagName)
    {
        TagName = tagName;
    }

    protected override void OnCreated()
    {
        Console.WriteLine($"{TagName} element created.");
    }

    protected override void OnInserted()
    {
        Console.WriteLine($"{TagName} element inserted.");
    }

    protected override void OnRemoved()
    {
        Console.WriteLine($"{TagName} element removed.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
   
        var element = new HTMLElement("div");
        element.Insert();  // Output: div element inserted.
        element.Remove();  
    }
}
