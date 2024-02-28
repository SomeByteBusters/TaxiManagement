namespace TaxiManagement0;

public class InputInterface
{
    private Kiosk _kiosk;

    public InputInterface()
    {
        float balance;
start:
        try
        {
            Console.WriteLine("Welcome to Taxi Management System");
            balance = handle_float(" - Guthaben: ");
            this._kiosk = new Kiosk(balance);
        }
        catch (Exception e)
        {
            balance = 0;
            Console.WriteLine(e);
            goto start;
            //throw;
        }
    }

    public int PrintMenu()
    {
        Console.WriteLine("\n --- Menü ---");
        Console.WriteLine("- Kaufen - ");
        Console.WriteLine("  1. Getränk kaufen");
        Console.WriteLine("  2. Prezel kaufen");
        Console.WriteLine("  3. Brötchen kaufen");
        Console.WriteLine("- Verkaufen - ");
        Console.WriteLine("  4. Getränk verkaufen");
        Console.WriteLine("  5. Prezel verkaufen");
        Console.WriteLine("  6. Brötchen verkaufen");
        Console.WriteLine("- Sonstiges -");
        Console.WriteLine("  7. Sortiere abgelaufene Wahren aus");
        Console.WriteLine("  8. Drucke erwarteten Gewinn");
        Console.WriteLine("  9. Drucke Inventar");
        Console.WriteLine(" 10. Beenden");

        int input = handle_int(" - Auswahl: (Index der Option)");

        switch (input)
        {
            case 1:
                buy_drink();
                break;
            case 2:
                buy_pretzel();
                break;
            case 3:
                buy_brotchen();
                break;
            case 4:
                sell_drink();
                break;
            case 5:
                sell_brezel();
                break;
            case 6:
                sell_brotchen();
                break;
            case 7:
                DiscardBakeries();
                break;
            case 8:
                PrintEstimatedGain();
                break;
            case 9:
                PrintData();
                break;
            case 10:
                Console.WriteLine("Beenden");
                return 1;
            default:
                Console.WriteLine("Input Zahl nicht zulässig");
                break;
        }

        Console.WriteLine("DRÜCKE ENTER UM FORTZUFAHREN");
        Console.ReadLine();

        return 0;
    }

// Einkaufspreis
// Verkaufspreis
// Ablaufdatum
// Hat Butter
// Typ
// Volumen
// Topping
// Anzahl

    private void buy_pretzel()
    {
        try
        {
            float cost = handle_float(" - Einkaufspreis: ");
            float price = handle_float(" - Verkaufspreis: ");
            int ex_date = handle_ex_date(" - Ablaufdatum:");
            bool buttered = handle_bool(" - Hat Butter Yes/No (y/n):");
            int count = handle_int(" - Anzahl: ");

            _kiosk.BuyPretzel(price, cost, ex_date, buttered, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void buy_drink()
    {
        try
        {
            float cost = handle_float(" - Einkaufspreis:");
            float price = handle_float(" - Verkaufspreis:");
            int ex_date = handle_ex_date(" - Ablaufdatum:");
            string type = handle_string(" - Typ:");
            float volume = handle_float(" - Volumen:");
            int count = handle_int(" - Anzahl:");

            _kiosk.BuyDrink(type, price, cost, ex_date, volume, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void buy_brotchen()
    {
        try
        {
            float cost = handle_float(" - Einkaufspreis:");
            float price = handle_float(" - Verkaufspreis:");
            int ex_date = handle_ex_date(" - Ablaufdatum:");
            string type = handle_string(" - Typ:");
            string topping = handle_string(" - Topping:");
            int count = handle_int(" - Anzahl:");

            _kiosk.BuyBrotchen(price, cost, ex_date, topping, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void sell_brezel()
    {
        try
        {
            bool buttered = handle_bool("Hat Butter Yes/No (y/n):");
            int count = handle_int(" - Anzahl:");

            _kiosk.SellPretzel(buttered, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void sell_drink()
    {
        try
        {
            string type = handle_string(" - Typ:");
            float volume = handle_float(" - Volumen:");
            int count = handle_int(" - Anzahl:");

            _kiosk.SellDrink(type, volume, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void sell_brotchen()
    {
        try
        {
            string type = handle_string(" - Typ:");
            string topping = handle_string(" - Topping:");
            int count = handle_int(" - Anzahl:");


            _kiosk.SellBrotchen(topping, count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void DiscardBakeries()
    {
        try
        {
            Console.WriteLine("Datum [JJJJMMDD]: ");
            int date = Convert.ToInt32(Console.ReadLine());
            _kiosk.DiscardBakeries(date);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void PrintData()
    {
        try
        {
            _kiosk.PrintEv();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private int PrintEstimatedGain()
    {
        Console.WriteLine("Estimated Gain: " + Convert.ToString(_kiosk.GetGain()));

        return 0;
    }

    // --- Handler ---


    private int handle_int(string name)
    {
        Console.WriteLine(name);
        int data = Convert.ToInt32(Console.ReadLine());
        return data;
    }

    private string handle_string(string name)
    {
        Console.WriteLine(name);
        return Console.ReadLine().ToLower();
    }

    private float handle_float(string name)
    {
        Console.WriteLine(name);
        string input = Console.ReadLine().Replace(",", ".");
        
        input = input.Replace(",", ".");
        if (!input.Contains('.'))
        {
            try
            {
                return Convert.ToSingle(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        string[] coll = input.Split(".");
        float left = Convert.ToSingle(coll[0]);
        double right = Convert.ToDouble(coll[1]);
        right = Math.Round(right, 2);
        return (left + Convert.ToSingle(right) / 100.0f);
    }

    private bool handle_bool(string name)
    {
        Console.WriteLine(name);
        bool data = get_bool(Console.ReadLine());
        return data;
    }

private int handle_ex_date(string name)
{
    Console.WriteLine(name);
    string input = Console.ReadLine().Replace(",", ".");
    if (!input.Contains('.'))
    {
        return Convert.ToInt32(input);
    }

    string[] coll = input.Split(".");
    string output = coll[2] + coll[1] + coll[0];
    return Convert.ToInt32(output);

}

    private bool get_bool(string input)
    {
        bool value;
        if (input == "y" || input == "yes")
        {
            value = true;
        }
        else if (input == "n" || input == "no")
        {
            value = false;
        }
        else
        {
            Console.WriteLine("(y/n):");
            string new_input = Console.ReadLine();
            value = handle_bool(new_input);
        }

        return value;
    }
}