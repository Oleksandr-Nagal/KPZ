using System;
using System.Collections.Generic;
public abstract class Subscription
{
    public decimal MonthlyFee { get; protected set; }
    public int MinPeriod { get; protected set; }
    public List<string> Channels { get; protected set; }
}
public class DomesticSubscription : Subscription
{
    public DomesticSubscription()
    {
        MonthlyFee = 10;
        MinPeriod = 1;
        Channels = new List<string> { "Domestic Channels" };
    }
}

public class EducationalSubscription : Subscription
{
    public EducationalSubscription()
    {
        MonthlyFee = 20;
        MinPeriod = 3;
        Channels = new List<string> { "Educational Channels" };
    }
}

public class PremiumSubscription : Subscription
{
    public PremiumSubscription()
    {
        MonthlyFee = 30;
        MinPeriod = 6;
        Channels = new List<string> { "Premium Channels" };
    }
}
public abstract class SubscriptionCreator
{
    public abstract Subscription CreateSubscription();
}
public class WebSite : SubscriptionCreator
{
    public override Subscription CreateSubscription()
    {
        Console.WriteLine("Creating subscription through website...");
        Console.WriteLine("Please choose the type of subscription:");
        Console.WriteLine("1. Domestic");
        Console.WriteLine("2. Educational");
        Console.WriteLine("3. Premium");
        
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                return new DomesticSubscription();
            case 2:
                return new EducationalSubscription();
            case 3:
                return new PremiumSubscription();
            default:
                throw new ArgumentException("Invalid choice");
        }
    }
}

public class MobileApp : SubscriptionCreator
{
    public override Subscription CreateSubscription()
    {
        Console.WriteLine("Creating subscription through mobile app...");
        Console.WriteLine("Please choose the type of subscription:");
        Console.WriteLine("1. Domestic");
        Console.WriteLine("2. Educational");
        Console.WriteLine("3. Premium");
        
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                return new DomesticSubscription();
            case 2:
                return new EducationalSubscription();
            case 3:
                return new PremiumSubscription();
            default:
                throw new ArgumentException("Invalid choice");
        }
    }
}

public class ManagerCall : SubscriptionCreator
{
    public override Subscription CreateSubscription()
    {
        Console.WriteLine("Creating subscription through manager call...");
        Console.WriteLine("Please choose the type of subscription:");
        Console.WriteLine("1. Domestic");
        Console.WriteLine("2. Educational");
        Console.WriteLine("3. Premium");
        
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                return new DomesticSubscription();
            case 2:
                return new EducationalSubscription();
            case 3:
                return new PremiumSubscription();
            default:
                throw new ArgumentException("Invalid choice");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        SubscriptionCreator website = new WebSite();
        Subscription subscription1 = website.CreateSubscription();
        Console.WriteLine("Мiсячна плата: " + subscription1.MonthlyFee);
        Console.WriteLine("Мiнiмальний перiод: " + subscription1.MinPeriod );
        Console.WriteLine(string.Join(", ", subscription1.Channels ) + '\n');

        SubscriptionCreator mobileApp = new MobileApp();
        Subscription subscription2 = mobileApp.CreateSubscription();
        Console.WriteLine("Мiсячна плата: " + subscription2.MonthlyFee);
        Console.WriteLine("Мiнiмальний перiод: " + subscription2.MinPeriod);
        Console.WriteLine(string.Join(", ", subscription2.Channels) + '\n');

        SubscriptionCreator managerCall = new ManagerCall();
        Subscription subscription3 = managerCall.CreateSubscription();
        Console.WriteLine("Мiсячна плата: " + subscription3.MonthlyFee);
        Console.WriteLine("Мiнiмальний перiод: " + subscription3.MinPeriod);
        Console.WriteLine(string.Join(", ", subscription3.Channels));
    }
}
