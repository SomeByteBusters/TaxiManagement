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

    public void BuyDrink(string type, float price, float volume, int count)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Drink(type, price, volume));
    }

    public void BuyPretzel(float price, bool buttered, int count)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Pretzel(price, buttered));
    }

    public void SuyBrotchen(float price, string topping, int count)
    {
        for(int i=count; i>0; i--)
            Products.Add(new Brotchen(price, topping));
    }

    public void SellDrink(string type, float volume, int count = 1)
    {
        foreach (var product in Products)
        {
            if(product is Drink)
            {
                Drink? drink = product as Drink;
                if(drink?.Type == type && drink?.Volume == volume)
                    
                    
            }
        }
    }

    public void SellPretzel(bool buttered, int count = 1)
    {
        
    }

    public void SellBrotchen(string topping, int count = 1)
    {
        
    }

    public void SiscardBakeries()
    {
        
    }

    public float getGain()
    {
        return 0;
    }
}