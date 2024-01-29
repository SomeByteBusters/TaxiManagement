namespace TaxiManagement0;

public class Brotchen(float price, float cost, int exDate, string type) : BakeryProd(price, cost, exDate)
{
    public string Type
    {
        get;
        protected set;
    } = type;
}