using System;
using System.Collections.Generic;

public class Money
{
    private int dollars;
    private int cents;

    public Money(int dollars, int cents)
    {
        this.dollars = dollars;
        this.cents = cents;
    }

    public void Print()
    {
        Console.WriteLine($"Грошi: {dollars} долар{i(dollars)} {cents} цент{i(cents)}");
    }

    private string i(int num)
    {
        return num != 1 ? "и" : "";
    }
}

public class Product
{
    private double price;

    public double Price 
    {
        get { return price; }
        set { price = value; }
    }

    public Product(double price)
    {
        this.price = price;
    }

    public void DecreasePrice(double amount)
    {
        price -= amount;
    }
}


public class Warehouse
{
    private string name;
    private string unit;
    private double unitPrice;
    private int quantity;
    private DateTime lastArrivalDate;

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Warehouse(string name, string unit, double unitPrice, int quantity, DateTime lastArrivalDate)
    {
        this.name = name;
        this.unit = unit;
        this.unitPrice = unitPrice;
        this.quantity = quantity;
        this.lastArrivalDate = lastArrivalDate;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Продукт: {name}, Одиниця вимiру: {unit}, Цiна за одиницю: {unitPrice}, Кiлькiсть: {quantity}, Останнiй прихiд: {lastArrivalDate}");
    }
}

public class Reporting
{
    private List<string> reports;
    private List<string> arrivalReports;
    private List<string> shipmentReports;

    public Reporting()
    {
        reports = new List<string>();
        arrivalReports = new List<string>();
        shipmentReports = new List<string>();
    }

    public void AddReport(string report)
    {
        reports.Add(report);
    }

    public void AddArrivalReport(string report)
    {
        arrivalReports.Add(report);
    }

    public void AddShipmentReport(string report)
    {
        shipmentReports.Add(report);
    }

    public void PrintReports()
    {
        foreach (var report in reports)
        {
            Console.WriteLine(report);
        }
    }

    public void PrintArrivalReports()
    {
        foreach (var report in arrivalReports)
        {
            Console.WriteLine(report);
        }
    }

    public void PrintShipmentReports()
    {
        foreach (var report in shipmentReports)
        {
            Console.WriteLine(report);
        }
    }
    public void InventoryReport(Warehouse warehouse)
    {
        warehouse.PrintInfo();
        string report = $"Звiт про iнвентаризацiю: Залишена кiлькiсть: {warehouse.Quantity}";
        reports.Add(report);
        Console.WriteLine(report);
    }

    public void RegisterArrival(Warehouse warehouse, string productName, int quantity, DateTime arrivalDate)
    {
        warehouse.PrintInfo();
        string report = $"Продукт {productName} прибув. Кiлькiсть: {quantity}, Дата: {arrivalDate}";
        reports.Add(report);
        arrivalReports.Add(report); 
        Console.WriteLine(report);
    }

    public void ShipGoods(Warehouse warehouse, string productName, int quantity)
    {
        warehouse.PrintInfo();
        string report = $"Продукт {productName} вiдвантажено. Кiлькiсть: {quantity}";
        reports.Add(report);
        shipmentReports.Add(report); 
        Console.WriteLine(report);
    }

}


class Program
{
    static void Main(string[] args)
    {
        Money money = new Money(100, 50);
        Product product = new Product(100.0);
        Warehouse warehouse = new Warehouse("Товар", "кг", 10.5, 100, DateTime.Now);
        Reporting reporting = new Reporting();
        int choice;
        do
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вивести грошi");
            Console.WriteLine("2. Зменшити цiну товару");
            Console.WriteLine("3. Цiна продукту");
            Console.WriteLine("4. Вивести iнформацiю про склад");
            Console.WriteLine("5. Зареєструвати прихiд товару");
            Console.WriteLine("6. Вiдвантажити товар");
            Console.WriteLine("7. Звiт про iнвентаризацiю");
            Console.WriteLine("8. Всi звiти приходу товару");
            Console.WriteLine("9. Всi звiти вiдвантаження товару");
            Console.WriteLine("0. Вихiд");
            Console.Write("Виберiть опцiю: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        money.Print();
                        break;
                    case 2:
                        Console.Write("Введiть суму для зменшення цiни: ");
                        double amount = double.Parse(Console.ReadLine());
                        product.DecreasePrice(amount);
                        break;
                    case 3:
                        Console.WriteLine($"Цiна продукту: {product.Price}");
                        break;
                    case 4:
                        warehouse.PrintInfo();
                        break;
                    case 5:
                        Console.Write("Введiть назву товару: ");
                        string productName = Console.ReadLine();
                        Console.Write("Введiть кiлькiсть: ");
                        int arrivalQuantity = int.Parse(Console.ReadLine());
                        reporting.RegisterArrival(warehouse, productName, arrivalQuantity, DateTime.Now);
                        break;
                    case 6:
                        Console.Write("Введiть назву товару: ");
                        string shippedProductName = Console.ReadLine();
                        Console.Write("Введiть кiлькiсть: ");
                        int shippedQuantity = int.Parse(Console.ReadLine());
                        reporting.ShipGoods(warehouse, shippedProductName, shippedQuantity); 
                        break;
                    case 7:
                        Console.WriteLine("Звiт про iнвентаризацiю:");
                        reporting.InventoryReport(warehouse);
                        break;
                    case 8:
                        Console.WriteLine("Звiти приходу товару:");
                        reporting.PrintArrivalReports();
                        break;
                    case 9:
                        Console.WriteLine("Звiти вiдвантаження товару:");
                        reporting.PrintShipmentReports();
                        break;
                    case 0:
                        Console.WriteLine("Програма завершила роботу.");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибiр. Спробуйте ще раз.");
                        break;
                }
            }
            else
            {Console.WriteLine("Введено некоректне значення. Спробуйте ще раз.");
            }
            Console.WriteLine();
        } while (choice != 0);
    }
}
