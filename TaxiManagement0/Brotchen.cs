namespace TaxiManagement0;

public class Brotchen(float price, float cost, int exDate, string topping) : BakeryProd(price, cost, exDate)
{
    public string Topping
    {
        get;
        protected set;
    } = topping;
}