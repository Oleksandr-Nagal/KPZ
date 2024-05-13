using System;
using System.Collections.Generic;
using System.Text;

public abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
    public abstract void AddEventListener(string eventType, EventHandler eventHandler);
    public abstract void RemoveEventListener(string eventType, EventHandler eventHandler);
}

public class LightTextNode : LightNode
{
    private readonly string _text;

    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML => _text;
    public override string InnerHTML => _text;

    public override void AddEventListener(string eventType, EventHandler eventHandler)
    {
        // Текстовий вузол не підтримує події
    }

    public override void RemoveEventListener(string eventType, EventHandler eventHandler)
    {
        // Текстовий вузол не підтримує події
    }
}

public class LightElementNode : LightNode
{
    private readonly string _tag;
    private readonly bool _blockType;
    private readonly bool _selfClosing;
    private readonly List<string> _classes;
    private readonly List<LightNode> _children;
    private readonly Dictionary<string, List<EventHandler>> _eventListeners;

    public LightElementNode(string tag, bool blockType, bool selfClosing, List<string> classes, List<LightNode> children)
    {
        _tag = tag;
        _blockType = blockType;
        _selfClosing = selfClosing;
        _classes = classes;
        _children = children;
        _eventListeners = new Dictionary<string, List<EventHandler>>();
    }

    public override string OuterHTML
    {
        get
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<{_tag}");
            if (_classes.Count > 0)
            {
                builder.Append(" class=\"");
                builder.Append(string.Join(" ", _classes));
                builder.Append("\"");
            }
            builder.Append(">");
            if (!_selfClosing)
            {
                foreach (var child in _children)
                {
                    builder.Append(child.OuterHTML);
                }
                builder.Append($"</{_tag}>");
            }
            return builder.ToString();
        }
    }

    public override string InnerHTML
    {
        get
        {
            StringBuilder builder = new StringBuilder();
            foreach (var child in _children)
            {
                builder.Append(child.OuterHTML);
            }
            return builder.ToString();
        }
    }

    public override void AddEventListener(string eventType, EventHandler eventHandler)
    {
        if (!_eventListeners.ContainsKey(eventType))
        {
            _eventListeners[eventType] = new List<EventHandler>();
        }
        _eventListeners[eventType].Add(eventHandler);
    }

    public override void RemoveEventListener(string eventType, EventHandler eventHandler)
    {
        if (_eventListeners.ContainsKey(eventType))
        {
            _eventListeners[eventType].Remove(eventHandler);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var title = new LightTextNode("Welcome to My Website");
        var paragraph1 = new LightTextNode("This is a simple paragraph.");
        var paragraph2 = new LightTextNode("This is another paragraph.");
        var listItems = new List<LightNode>
        {
            new LightTextNode("Item 1"),
            new LightTextNode("Item 2"),
            new LightTextNode("Item 3")
        };
        var unorderedList = new LightElementNode("ul", true, false, new List<string>(), listItems);

        var bodyChildren = new List<LightNode> { paragraph1, paragraph2, unorderedList };
        var body = new LightElementNode("body", true, false, new List<string>(), bodyChildren);

        var htmlChildren = new List<LightNode> { title, body };
        var html = new LightElementNode("html", true, false, new List<string>(), htmlChildren);

        // Додамо подію click для заголовка
        title.AddEventListener("click", (sender, e) => Console.WriteLine("Title clicked!"));

        Console.WriteLine("Inner HTML of the page:");
        Console.WriteLine(html.InnerHTML);
        Console.WriteLine();
        Console.WriteLine("Outer HTML of the page:");
        Console.WriteLine(html.OuterHTML);
    }
}
