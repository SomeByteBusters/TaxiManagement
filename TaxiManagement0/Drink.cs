namespace TaxiManagement0;

public class Drink(string type, float price, float volume, float volAlc = 0) : Product(price)
{
    public string Type
    {
        get;
        private set;
    } = type;

    public float Volume  // Liter
    {
        get;
        private set;
    } = volume;

    public float VolAlc  // %
    {
        get;
        private set;
    } = volAlc;
}