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

    public void BuyDrink(string type, float price, float cost, int exDate, float volume, int count=1)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Drink(type, price, cost, exDate, volume));
    }

    public void BuyPretzel(float price, float cost, int exDate, bool buttered, int count)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Pretzel(price, cost, exDate, buttered));
    }

    public void BuyBrotchen(float price, float cost, int exDate, string topping, int count)
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
                if (drink?.Type == type && Equals(drink.Volume, volume))
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
        foreach (var product in Products)
        {
            if(product is Prezel)
            {
                Prezel? prezel = product as Prezel;
                if (prezel?.buttered == buttered)
                {
                    Balance += prezel.Price;
                    Products.Remove(prezel);
                    return;
                }
            }
        }
    }

    public void SellBrotchen(string topping, int count = 1)
    {
        foreach (var product in Products)
        {
            if(product is Brotchen)
            {
                Brotchen? brotchen = product as Brotchen;
                if (brotchen?.topping == topping)
                {
                    Balance += brotchen.Price;
                    Products.Remove(brotchen);
                    return;
                }
            }
        }
    }

    public void DiscardBakeries(int date)
    {
        foreach (var item in this.Products) {
            if item.exDate > date
                Products.Remove(item);
        }
    }

    public float GetGain()
    {
        float output = 0.0f;
        foreach(var item in this.Products) {
            float item_price = item.price;
            float item_cost = item.cost;
            float profit = item_cost - item_price; // TODO
            output += profit;
        }
        return output;
    }
}
