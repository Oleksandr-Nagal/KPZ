using System;
using System.Collections.Generic;

public interface IVisitor
{
    void Visit(HTMLElement element);
}

public class HighlightVisitor : IVisitor
{
    public void Visit(HTMLElement element)
    {
        if (element.TagName == "p")
        {
            element.Highlighted = true;
        }
    }
}

public class HTMLElement
{
    public string TagName { get; set; }
    public bool Highlighted { get; set; } = false;
    public List<HTMLElement> Children { get; set; } = new List<HTMLElement>();

    public HTMLElement(string tagName)
    {
        TagName = tagName;
    }

    public void AddChild(HTMLElement child)
    {
        Children.Add(child);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var child in Children)
        {
            child.Accept(visitor);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var root = new HTMLElement("root");
        var child1 = new HTMLElement("div");
        var child2 = new HTMLElement("p");
        root.AddChild(child1);
        root.AddChild(child2);

        var highlightVisitor = new HighlightVisitor();
        root.Accept(highlightVisitor);

        Console.WriteLine(child2.Highlighted); // Output: True
    }
}
