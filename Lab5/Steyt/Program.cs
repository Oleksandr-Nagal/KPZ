using System;

public abstract class ElementState
{
    protected HTMLElement _element;

    protected ElementState(HTMLElement element)
    {
        _element = element;
    }

    public abstract void Enter();
    public abstract void Exit();
}

public class VisibleState : ElementState
{
    public VisibleState(HTMLElement element) : base(element) { }

    public override void Enter()
    {
        _element.Visible = true;
    }

    public override void Exit()
    {
        _element.Visible = false;
    }
}

public class HiddenState : ElementState
{
    public HiddenState(HTMLElement element) : base(element) { }

    public override void Enter()
    {
        _element.Visible = false;
    }

    public override void Exit()
    {
        _element.Visible = true;
    }
}

public class HTMLElement
{
    public string TagName { get; set; }
    public bool Visible { get; set; } = true;

    public HTMLElement(string tagName)
    {
        TagName = tagName;
    }
}

public class Context
{
    private ElementState _currentState;

    public void TransitionTo(ElementState state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Usage
        var element = new HTMLElement("p");
        var context = new Context();

        context.TransitionTo(new HiddenState(element));
        Console.WriteLine(element.Visible); // Output: False

        context.TransitionTo(new VisibleState(element));
        Console.WriteLine(element.Visible); // Output: True
    }
}
