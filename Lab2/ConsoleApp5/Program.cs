using System;
using System.Collections.Generic;

// Клас для створення героїв
public class HeroBuilder
{
    protected string Name;
    protected string Gender;
    protected int Height;
    protected string HairColor;
    protected string EyeColor;
    protected string Clothing;
    protected List<string> Inventory;

    public HeroBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public HeroBuilder SetGender(string gender)
    {
        Gender = gender;
        return this;
    }

    public HeroBuilder SetHeight(int height)
    {
        Height = height;
        return this;
    }

    public HeroBuilder SetHairColor(string hairColor)
    {
        HairColor = hairColor;
        return this;
    }

    public HeroBuilder SetEyeColor(string eyeColor)
    {
        EyeColor = eyeColor;
        return this;
    }

    public HeroBuilder SetClothing(string clothing)
    {
        Clothing = clothing;
        return this;
    }

    public HeroBuilder AddToInventory(string item)
    {
        if (Inventory == null)
        {
            Inventory = new List<string>();
        }
        Inventory.Add(item);
        return this;
    }

    public Hero Build()
    {
        return new Hero(Name, Gender, Height, HairColor, EyeColor, Clothing, Inventory);
    }

    public Enemy BuildEnemy(List<string> evilDeeds)
    {
        return new Enemy(Name, Gender, Height, HairColor, EyeColor, Clothing, Inventory, evilDeeds);
    }
}

// Клас героя
public class Hero
{
    public string Name { get; }
    public string Gender { get; }
    public int Height { get; }
    public string HairColor { get; }
    public string EyeColor { get; }
    public string Clothing { get; }
    public List<string> Inventory { get; }

    public Hero(string name, string gender, int height, string hairColor, string eyeColor, string clothing, List<string> inventory)
    {
        Name = name;
        Gender = gender;
        Height = height;
        HairColor = hairColor;
        EyeColor = eyeColor;
        Clothing = clothing;
        Inventory = inventory;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}, Gender: {Gender}, Height: {Height}, Hair Color: {HairColor}, Eye Color: {EyeColor}, Clothing: {Clothing}");
        Console.WriteLine("Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine("- " + item);
        }
    }
}

// Клас ворога
public class Enemy : Hero
{
    public List<string> EvilDeeds { get; }

    public Enemy(string name, string gender, int height, string hairColor, string eyeColor, string clothing, List<string> inventory, List<string> evilDeeds)
        : base(name, gender, height, hairColor, eyeColor, clothing, inventory)
    {
        EvilDeeds = evilDeeds;
    }

    public void ShowEvilDeeds()
    {
        Console.WriteLine("Evil Deeds:");
        foreach (var deed in EvilDeeds)
        {
            Console.WriteLine("- " + deed);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        HeroBuilder heroBuilder = new HeroBuilder();
        Hero hero = heroBuilder
            .SetName("Hero")
            .SetGender("Male")
            .SetHeight(180)
            .SetHairColor("Brown")
            .SetEyeColor("Blue")
            .SetClothing("Armor")
            .AddToInventory("Sword")
            .AddToInventory("Shield")
            .Build();

        Console.WriteLine("Hero:");
        hero.ShowInfo();
        Console.WriteLine();

        List<string> evilDeeds = new List<string> { "Destroyed the village", "Stole the king's treasure" };
        Enemy enemy = heroBuilder
            .SetName("Enemy")
            .SetGender("Female")
            .SetHeight(160)
            .SetHairColor("Black")
            .SetEyeColor("Red")
            .SetClothing("Dark Robe")
            .AddToInventory("Magic Staff")
            .BuildEnemy(evilDeeds);

        Console.WriteLine("\nEnemy:");
        enemy.ShowInfo();
        enemy.ShowEvilDeeds();
    }
}
