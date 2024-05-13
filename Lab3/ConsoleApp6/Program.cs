using System;
using System.Collections.Generic;
using System.Text;

public abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
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
}

public class LightElementNode : LightNode
{
    private readonly string _tag;
    private readonly bool _blockType;
    private readonly bool _selfClosing;
    private readonly List<string> _classes;
    private readonly List<LightNode> _children;

    public LightElementNode(string tag, bool blockType, bool selfClosing, List<string> classes, List<LightNode> children)
    {
        _tag = tag;
        _blockType = blockType;
        _selfClosing = selfClosing;
        _classes = classes;
        _children = children;
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
}

public class LightWeightNode : LightNode
{
    private readonly string _content;

    public LightWeightNode(string content)
    {
        _content = content;
    }

    public override string OuterHTML => _content;
    public override string InnerHTML => _content;
}

class Program
{
    static void Main(string[] args)
    {
        var h1 = new LightWeightNode("<h1>Chapter 1: Introduction</h1>");
        var h2 = new LightWeightNode("<h2>Section 1.1: Overview</h2>");
        var p1 = new LightWeightNode("<p>This is the first paragraph of the introduction.</p>");
        var p2 = new LightWeightNode("<p>This is the second paragraph of the introduction.</p>");
        var blockquote = new LightWeightNode("<blockquote>This is a blockquote.</blockquote>");

        Console.WriteLine("Outer HTML:");
        Console.WriteLine(h1.OuterHTML);
        Console.WriteLine(h2.OuterHTML);
        Console.WriteLine(p1.OuterHTML);
        Console.WriteLine(p2.OuterHTML);
        Console.WriteLine(blockquote.OuterHTML);
        Console.WriteLine();

        Console.WriteLine("Inner HTML:");
        Console.WriteLine(h1.InnerHTML);
        Console.WriteLine(h2.InnerHTML);
        Console.WriteLine(p1.InnerHTML);
        Console.WriteLine(p2.InnerHTML);
        Console.WriteLine(blockquote.InnerHTML);
    }
}
