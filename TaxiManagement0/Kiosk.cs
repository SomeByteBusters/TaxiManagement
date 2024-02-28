namespace TaxiManagement0;

public class Kiosk(float balance)
{
    private List<Product> Products { get; set; } = new List<Product>();

    private float Balance { get; set; } = balance;

    public void PrintEv()
    {
        Console.WriteLine("Balance: {0}", Balance);
        foreach (var item in Products)
            item.Print();

        //Console.WriteLine("Products: {0}", Products);
    }

    public void printProdCount()
    {
        Console.WriteLine("Products: {0}", Products.Count);
    }

    public void BuyDrink(string type, float price, float cost, int exDate, float volume, int count = 1)
    {
        for (var i = count; i > 0; i--)
        {
            Products.Add(new Drink(type, price, cost, exDate, volume));
            this.Balance -= cost;
        }
    }

    public void BuyPretzel(float price, float cost, int exDate, bool buttered, int count)
    {
        for (int i = count; i > 0; i--)
        {
            Products.Add(new Pretzel(price, cost, exDate, buttered));
            this.Balance -= cost;
        }
    }

    public void BuyBrotchen(float price, float cost, int exDate, string topping, int count)
    {
        for (var i = count; i > 0; i--)
        {
            Products.Add(new Brotchen(price, cost, exDate, topping));
            this.Balance -= cost;
        }
    }

    public void SellDrink(string type, float volume, int count)
    {
        try
        {
            for (int i = count; i > 0; i--)
            {
                var selledProducts = new List<Product>();
                foreach (var product in Products)
                {
                    if (product is not Drink drink) continue;
                    if (!Equals(drink.Volume, volume) || !Equals(drink.Type, type)) continue;
                    Balance += drink.Price;
                    selledProducts.Add(drink);
                }

                foreach (var product in selledProducts)
                    Products.Remove(product);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void SellPretzel(bool buttered, int count)
    {
        try
        {
            List<Product> selledProducts = new List<Product>();
            foreach (var product in Products)
            {
                if (product is not Pretzel pretzel) continue;
                if (pretzel.Buttered != buttered) continue;
                if (selledProducts.Count == count) break;

                selledProducts.Add(pretzel);
                Balance += pretzel.Price;
            }

            foreach (var product in selledProducts)
                Products.Remove(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void SellBrotchen(string topping, int count = 1)
    {
        try
        {
            List<Product> selledProducts = new List<Product>();
            foreach (var product in Products)
            {
                if (product is not Brotchen brotchen) continue;
                if (brotchen?.Topping != topping) continue;

                Balance += brotchen.Price;
                selledProducts.Add(brotchen);
            }

            foreach (var product in selledProducts)
                Products.Remove(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void DiscardBakeries(int date)
    {
        Console.WriteLine("Discarding bakeries:");
        List<Product> discardProducts = new List<Product>();
        foreach (var item in Products)
        {
            if (item.ExDate < date)
                discardProducts.Add(item);
        }

        foreach (var item in discardProducts)
        {
            Products.Remove(item);
            item.Print();
        }
    }

    public void PrintAvailablePretzels(bool buttered = false)
    {
        var fitting = new List<Product>();
        foreach (var product in Products)
        {
            if(product is Pretzel pretzel)
                fitting.Add(pretzel);
        }

        foreach (var product in fitting)
        {
            product.Print();
            
        }
    }

    public float GetGain()
    {
        return Products.Sum(item => item.Price - item.Cost);
    }

    public void print_all_by_name(string name) {
        string[] drink_names = {"getränke", "getränk", "drink", "drinks"};
        string[] pretzel_names = {"pretzel", "brezel", "pretzeln", "brezeln"};
        string[] brotchen_names = {"brot", "brötchen"};
        name = name.ToLower().Trim();

        foreach (var p_name in pretzel_names) {
            if (p_name == name) { print_all_pretzels() }
        }
        

    }
}
