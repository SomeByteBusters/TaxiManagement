// See https://aka.ms/new-console-template for more information

using TaxiManagement0;

Console.WriteLine("Hello, World!");

InputInterface inter = new InputInterface();
int stop;

do
{
    stop = inter.PrintMenu();
}
while(stop != 1);

