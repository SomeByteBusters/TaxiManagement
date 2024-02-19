namespace TaxiManagement0;

public class Brotchen(float price, float cost, int exDate, string type, string topping) : BakeryProd(price, cost, exDate)
{
    public string Type
    {
        get;
        protected set;
    } = type;
    public string Topping
    {
        get;
        protected set;
    } = topping;
}