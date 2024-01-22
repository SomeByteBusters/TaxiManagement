namespace TaxiManagement0;

public class Brotchen(float price, float cost, float exDate, string type) : BakeryProd(price, cost, exDate)
{
    private string Type
    {
        get;
    } = type;
}