// See https://aka.ms/new-console-template for more information

using TaxiManagement0;

Console.WriteLine("Hello, World!");
Kiosk kiosk = new Kiosk(100);
kiosk.PrintEv();

kiosk.BuyDrink("IngwerLimonade", 3, 1, 20240213, 10, 3);
kiosk.PrintEv();

kiosk.SellDrink("IngwerLimonade", 10, 3);
kiosk.PrintEv();