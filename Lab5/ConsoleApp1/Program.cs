using System;
using System.Collections.Generic;
// Ітератор
public interface IIterator<T>
{
    T Next();
    bool HasNext();
}

// Команда
public interface ICommand
{
    void Execute();
    void Undo();
}

// Стейт
public class Memento
{
    // Збереження стану
}

public class Originator
{
    private Memento _state;

    public Memento SaveState()
    {
        // Збереження поточного стану
    }

    public void RestoreState(Memento memento)
    {
        // Відновлення стану з мементо
    }
}

// Шаблонний метод
public abstract class HTMLNode
{
    public virtual void OnCreated() { }
    public virtual void OnInserted() { }
    public virtual void OnRemoved() { }
    public virtual void OnStylesApplied() { }
    // Додаткові методи життєвого циклу
}

// Відвідувач
public interface IVisitor
{
    void VisitElement(HTMLElement element);
    void VisitText(HTMLText text);
}

public class HTMLElement : HTMLNode
{
    public override void Accept(IVisitor visitor)
    {
        visitor.VisitElement(this);
    }
}

public class HTMLText : HTMLNode
{
    public override void Accept(IVisitor visitor)
    {
        visitor.VisitText(this);
    }
}
