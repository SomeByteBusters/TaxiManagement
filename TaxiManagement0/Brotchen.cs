namespace TaxiManagement0;

public class Brotchen(float price, string type) : BakeryProd(price)
{
    private string Type
    {
        get;
    } = type;
}