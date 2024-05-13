using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(double weight, int age, string name, string type)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        Children = new List<Virus>();
    }

    public object Clone()
    {
        Virus clone = new Virus(this.Weight, this.Age, this.Name, this.Type);
        foreach (var child in Children)
        {
            clone.Children.Add((Virus)child.Clone());
        }
        return clone;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Virus grandparentVirus = new Virus(2.5, 1, "Grandparent Virus", "A");
        Virus parentVirus1 = new Virus(1.8, 2, "Parent Virus 1", "B");
        Virus parentVirus2 = new Virus(2.0, 2, "Parent Virus 2", "C");

        grandparentVirus.Children.Add(parentVirus1);
        grandparentVirus.Children.Add(parentVirus2);

        Virus childVirus1 = new Virus(1.2, 1, "Child Virus 1", "D");
        Virus childVirus2 = new Virus(1.0, 1, "Child Virus 2", "E");
        parentVirus1.Children.Add(childVirus1);
        parentVirus1.Children.Add(childVirus2);

        Virus grandChildVirus1 = new Virus(0.8, 1, "Grandchild Virus 1", "F");
        Virus grandChildVirus2 = new Virus(0.7, 1, "Grandchild Virus 2", "G");
        childVirus1.Children.Add(grandChildVirus1);
        childVirus2.Children.Add(grandChildVirus2);

        Virus clonedGrandparent = (Virus)grandparentVirus.Clone();
        Virus clonedParent1 = (Virus)parentVirus1.Clone();

        Console.WriteLine("Cloned Grandparent Virus:");
        clonedGrandparent.DisplayInfo();
        Console.WriteLine("\nCloned Parent Virus 1:");
        clonedParent1.DisplayInfo();
    }
}
