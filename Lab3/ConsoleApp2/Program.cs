using System;
using System.Collections.Generic;


public interface IInventory
{
    void Equip();
}


public abstract class Hero
{
    protected string Name;
    protected List<IInventory> Inventories = new List<IInventory>();

    public Hero(string name)
    {
        Name = name;
    }

    public void AddInventory(IInventory inventory)
    {
        Inventories.Add(inventory);
    }

    public virtual void ShowInventories()
    {
        Console.WriteLine($"Inventories for {Name}:");
        foreach (var inventory in Inventories)
        {
            inventory.Equip();
        }
    }
}

// Клас Warrior
public class Warrior : Hero
{
    public Warrior(string name) : base(name)
    {
    }

    public override void ShowInventories()
    {
        Console.WriteLine("\nWarrior Inventories:");
        base.ShowInventories();
    }
}

// Клас Mage
public class Mage : Hero
{
    public Mage(string name) : base(name)
    {
    }

    public override void ShowInventories()
    {
        Console.WriteLine("\nMage Inventories:");
        base.ShowInventories();
    }
}

// Клас Palladin
public class Palladin : Hero
{
    public Palladin(string name) : base(name)
    {
    }

    public override void ShowInventories()
    {
        Console.WriteLine("\nPalladin Inventories:");
        base.ShowInventories();
    }
}

public abstract class InventoryDecorator : IInventory
{
    protected IInventory Inventory;

    protected InventoryDecorator(IInventory inventory)
    {
        Inventory = inventory;
    }

    public virtual void Equip()
    {
        Inventory?.Equip();
    }
}

public class WeaponDecorator : InventoryDecorator
{
    private readonly string _weaponName;

    public WeaponDecorator(IInventory inventory, string weaponName) : base(inventory)
    {
        _weaponName = weaponName;
    }

    public override void Equip()
    {
        base.Equip();
        Console.WriteLine($"Weapon: {_weaponName}");
    }
}
public class ArmorDecorator : InventoryDecorator
{
    private readonly string _armorName;

    public ArmorDecorator(IInventory inventory, string armorName) : base(inventory)
    {
        _armorName = armorName;
    }

    public override void Equip()
    {
        base.Equip();
        Console.WriteLine($"Armor: {_armorName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Warrior warrior = new Warrior("Warrior1");
        Mage mage = new Mage("Mage1");
        Palladin palladin = new Palladin("Palladin1");

        warrior.AddInventory(new WeaponDecorator(null, "Sword"));
        warrior.AddInventory(new ArmorDecorator(null, "Chainmail"));
        warrior.AddInventory(new WeaponDecorator(new ArmorDecorator(null, "Leather Armor"), "Axe"));
        mage.AddInventory(new WeaponDecorator(null, "Staff"));
        mage.AddInventory(new ArmorDecorator(null, "Robe"));
        mage.AddInventory(new WeaponDecorator(new ArmorDecorator(null, "Cloth Armor"), "Wand"));
        palladin.AddInventory(new WeaponDecorator(null, "Mace"));
        palladin.AddInventory(new ArmorDecorator(null, "Plate Armor"));
        palladin.AddInventory(new WeaponDecorator(new ArmorDecorator(null, "Plate Armor"), "Shield"));

        warrior.ShowInventories();
        mage.ShowInventories();
        palladin.ShowInventories();
    }
}
