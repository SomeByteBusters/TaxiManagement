namespace TaxiManagement0;

public class Kiosk(float balance)
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
    } = balance;

    public void PrintEv()
    {
        Console.WriteLine("Balance: {0}", Balance);
        foreach (var item in Products)
            item.Print();

        //Console.WriteLine("Products: {0}", Products);
    }

    public void BuyDrink(string type, float price, float cost, int exDate, float volume, int count=1)
    {
        for (var i = count; i > 0; i--)
        {
            Products.Add(new Drink(type, price, cost, exDate, volume));
            this.Balance -= price;
        }
    }

    public void BuyPretzel(float price, float cost, int exDate, bool buttered, int count)
    {
        for(int i = count; i>0; i--)
            Products.Add(new Pretzel(price, cost, exDate, buttered));
    }

    public void BuyBrotchen(float price, float cost, int exDate, string type,  string topping, int count)
    {
        for(var i=count; i>0; i--)
            Products.Add(new Brotchen(price, cost, exDate, type, topping));
    }

    public void SellDrink(string type, float volume, int count)
    {
        for (int i = count; i > 0; i--)
        {
            foreach (var product in Products)
            {
                try
                {
                    if (product is not Drink drink) continue;
                    if (!Equals(drink.Volume, volume) || !Equals(drink.Type, type)) continue;
                    Balance += drink.Price;
                    Products.Remove(drink);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

    public void SellPretzel(bool buttered, int count = 1)
    {
        foreach (var product in Products)
        {
            if (product is not Pretzel pretzel) continue;
            if (pretzel.Buttered != buttered) continue;
            
            Balance += pretzel.Price;
            Products.Remove(pretzel);
            return;
        }
    }

    public void SellBrotchen(string topping, int count = 1)
    {
        foreach (var product in Products)
        {
            if (product is not Brotchen brotchen) continue;
            if (brotchen?.Topping != topping) continue;
            
            Balance += brotchen.Price;
            Products.Remove(brotchen);
            return;
        }
    }

    public void DiscardBakeries(int date)
    {
        foreach (var item in this.Products) {
            if(item.ExDate > date)
                Products.Remove(item);
        }
    }

    public float GetGain()
    {
        return Products.Sum(item => item.Price - item.Cost);
    }
}
