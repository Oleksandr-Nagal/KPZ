using System;

public abstract class Device
{
    public string Model { get; set; }
    public string Brand { get; set; }

    public abstract void DisplayInfo();
}

public class Laptop : Device
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Laptop: {Brand} {Model}");
    }
}

public class Netbook : Device
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Netbook: {Brand} {Model}");
    }
}

public class EBook : Device
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"EBook: {Brand} {Model}");
    }
}

public class Smartphone : Device
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Smartphone: {Brand} {Model}\n");
    }
}

public abstract class DeviceFactory
{
    public abstract Laptop CreateLaptop();
    public abstract Netbook CreateNetbook();
    public abstract EBook CreateEBook();
    public abstract Smartphone CreateSmartphone();
}

public class IPhoneFactory : DeviceFactory
{
    public override Laptop CreateLaptop()
    {
        return new Laptop { Brand = "IPhone", Model = "IPhone Laptop" };
    }

    public override Netbook CreateNetbook()
    {
        return new Netbook { Brand = "IPhone", Model = "IPhone Netbook" };
    }

    public override EBook CreateEBook()
    {
        return new EBook { Brand = "IPhone", Model = "IPhone EBook" };
    }

    public override Smartphone CreateSmartphone()
    {
        return new Smartphone { Brand = "IPhone", Model = "IPhone Smartphone" };
    }
}

public class XiaomiFactory : DeviceFactory
{
    public override Laptop CreateLaptop()
    {
        return new Laptop { Brand = "Xiaomi", Model = "Xiaomi Laptop" };
    }

    public override Netbook CreateNetbook()
    {
        return new Netbook { Brand = "Xiaomi", Model = "Xiaomi Netbook" };
    }

    public override EBook CreateEBook()
    {
        return new EBook { Brand = "Xiaomi", Model = "Xiaomi EBook" };
    }

    public override Smartphone CreateSmartphone()
    {
        return new Smartphone { Brand = "Xiaomi", Model = "Xiaomi Smartphone" };
    }
}

public class GalaxyFactory : DeviceFactory
{
    public override Laptop CreateLaptop()
    {
        return new Laptop { Brand = "Galaxy", Model = "Galaxy Laptop" };
    }

    public override Netbook CreateNetbook()
    {
        return new Netbook { Brand = "Galaxy", Model = "Galaxy Netbook" };
    }

    public override EBook CreateEBook()
    {
        return new EBook { Brand = "Galaxy", Model = "Galaxy EBook" };
    }

    public override Smartphone CreateSmartphone()
    {
        return new Smartphone { Brand = "Galaxy", Model = "Galaxy Smartphone" };
    }
}

class Program
{
    static void Main(string[] args)
    {
        DeviceFactory factory1 = new IPhoneFactory();
        Device laptop1 = factory1.CreateLaptop();
        Device netbook1 = factory1.CreateNetbook();
        Device ebook1 = factory1.CreateEBook();
        Device smartphone1 = factory1.CreateSmartphone();

        laptop1.DisplayInfo();
        netbook1.DisplayInfo();
        ebook1.DisplayInfo();
        smartphone1.DisplayInfo();

        DeviceFactory factory2 = new XiaomiFactory();
        Device laptop2 = factory2.CreateLaptop();
        Device netbook2 = factory2.CreateNetbook();
        Device ebook2 = factory2.CreateEBook();
        Device smartphone2 = factory2.CreateSmartphone();

        laptop2.DisplayInfo();
        netbook2.DisplayInfo();
        ebook2.DisplayInfo();
        smartphone2.DisplayInfo();

        DeviceFactory factory3 = new GalaxyFactory();
        Device laptop3 = factory3.CreateLaptop();
        Device netbook3 = factory3.CreateNetbook();
        Device ebook3 = factory3.CreateEBook();
        Device smartphone3 = factory3.CreateSmartphone();

        laptop3.DisplayInfo();
        netbook3.DisplayInfo();
        ebook3.DisplayInfo();
        smartphone3.DisplayInfo();
    }
}
