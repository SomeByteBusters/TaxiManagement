namespace TaxiManagement0;

public class Kiosk(float Balance)
{
    private List<Product> Products
    {
        get;
        set;
    } = new List<Product>();

    private float Balance
    {
        get;
        set;
    }

    public void PrintEv()
    {
        Console.WriteLine("Balance: {0}", Balance);
        //Console.WriteLine("Products: {0}", Products);
    }

    public void BuyDrink(string type, float price, float cost, float exDate, float volume, int count=1)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Drink(type, price, cost, exDate, volume));
    }

    public void BuyPretzel(float price, float cost, float exDate, bool buttered, int count)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Pretzel(price, cost, exDate, buttered));
    }

    public void BuyBrotchen(float price, float cost, float exDate, string topping, int count)
    {
        for(int i=count; i>0; i--)
            Products.Add(new Brotchen(price, cost, exDate, topping));
    }

    public void SellDrink(string type, float volume, int count = 1)
    {
        foreach (var product in Products)
        {
            if(product is Drink)
            {
                Drink? drink = product as Drink;
                if (drink?.Type == type && drink?.Volume == volume)
                {
                    Balance += drink.Price;
                    Products.Remove(drink);
                    return;
                }
            }
        }
    }

    public void SellPretzel(bool buttered, int count = 1)
    {
        
    }

    public void SellBrotchen(string topping, int count = 1)
    {
        
    }

    public void DiscardBakeries()
    {
        
    }

    public float GetGain()
    {
        return 0;
    }
}