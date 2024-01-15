// Интерфейс для зарядки через европейскую розетку

interface IEuropeCharge
{
    void ChargeEuropeSocket();
}

// Класс для работы с метрами
class EuropeCharge : IEuropeCharge
{
    private double _duration;

    public EuropeCharge(double duration)
    {
        _duration = duration;
    }

    public void ChargeEuropeSocket()
    {
        Console.WriteLine($"Charge with the help of europinian socket {_duration} hours");
    }
}

// Интерфейс для зарядки через американскую зарядку
interface IUsaCharge
{
    void ChargeUsaSocket();
}

// Адаптер для нашей зарядки под американские разетки
class UsaChargeAdapter : IUsaCharge
{
    private IEuropeCharge _europeCharge;

    public UsaChargeAdapter(IEuropeCharge europeCharge)
    {
        _europeCharge = europeCharge;
    }

    public void ChargeUsaSocket()
    {
        Console.WriteLine("Installing usa adapter to our socket and trying to charge with the help of our europinian charge");
        _europeCharge.ChargeEuropeSocket();
    }
}

class Program
{
    static void Main(string[] args)
    {
        EuropeCharge europinianCharge = new EuropeCharge(5);

        UsaChargeAdapter usaChargeAdapter = new UsaChargeAdapter(europinianCharge);

        usaChargeAdapter.ChargeUsaSocket();
    }
}