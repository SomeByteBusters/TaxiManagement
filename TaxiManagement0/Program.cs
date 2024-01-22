// See https://aka.ms/new-console-template for more information

using TaxiManagement0;

Console.WriteLine("Hello, World!");
Kiosk kiosk = new Kiosk(100);
kiosk.BuyDrink("IngwerLimonade", 3, 1, 0.3f, 10);
kiosk.PrintEv();