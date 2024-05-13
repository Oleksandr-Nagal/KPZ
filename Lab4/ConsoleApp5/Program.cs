using System;
using System.Collections.Generic;

public class TextDocument
{
    public string Content { get; set; }

    public TextDocument(string content)
    {
        Content = content;
    }

    public TextDocumentMemento CreateMemento()
    {
        return new TextDocumentMemento(Content);
    }

    public void RestoreMemento(TextDocumentMemento memento)
    {
        Content = memento.Content;
    }
}

public class TextDocumentMemento
{
    public string Content { get; }

    public TextDocumentMemento(string content)
    {
        Content = content;
    }
}

public class TextEditor
{
    private readonly Stack<TextDocumentMemento> _mementos = new Stack<TextDocumentMemento>();
    private readonly TextDocument _document;

    public TextEditor(TextDocument document)
    {
        _document = document;
    }

    public void Save()
    {
        _mementos.Push(_document.CreateMemento());
        Console.WriteLine("Document state saved.");
    }

    public void Undo()
    {
        if (_mementos.Count > 0)
        {
            var memento = _mementos.Pop();
            _document.RestoreMemento(memento);
            Console.WriteLine("Undo successful.");
        }
        else
        {
            Console.WriteLine("No previous states to undo.");
        }
    }

    public void DisplayDocument()
    {
        Console.WriteLine("Current document content:");
        Console.WriteLine(_document.Content);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var document = new TextDocument("Initial document content.");

        var editor = new TextEditor(document);

        editor.DisplayDocument();

        editor.Save();

        document.Content = "Modified document content.";

        editor.DisplayDocument();

        editor.Undo();

        editor.DisplayDocument();
    }
}
