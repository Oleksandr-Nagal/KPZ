public class Authenticator
{
    private static Authenticator instance;

    private Authenticator() { }

    public static Authenticator GetInstance()
    {
        if (instance == null)
        {
            instance = new Authenticator();
        }
        return instance;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Authenticator authenticator1 = Authenticator.GetInstance();
        Authenticator authenticator2 = Authenticator.GetInstance();

        Console.WriteLine(authenticator1 == authenticator2); // Виведе "True", якщо обидва об'єкти є посиланням на один і той же екземпляр
    }
}
