using System;
using System.Collections;
using System.Collections.Generic;

public class HTMLElement
{
    public string TagName { get; set; }
    public List<HTMLElement> Children { get; set; } = new List<HTMLElement>();

    public HTMLElement(string tagName)
    {
        TagName = tagName;
    }

    public void AddChild(HTMLElement child)
    {
        Children.Add(child);
    }
}

public class ElementIterator : IEnumerator<HTMLElement>
{
    private Stack<HTMLElement> stack = new Stack<HTMLElement>();
    private HTMLElement current;

    public ElementIterator(HTMLElement root)
    {
        stack.Push(root);
    }

    public bool MoveNext()
    {
        if (stack.Count == 0) return false;
        current = stack.Pop();
        for (int i = current.Children.Count - 1; i >= 0; i--)
        {
            stack.Push(current.Children[i]);
        }
        return true;
    }

    public void Reset()
    {
        stack.Clear();
    }

    public HTMLElement Current => current;

    object IEnumerator.Current => Current;

    public void Dispose() { }
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

        var iterator = new ElementIterator(root);
        while (iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current.TagName);
        }
    }
}
