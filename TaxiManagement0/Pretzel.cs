namespace TaxiManagement0;

public class Pretzel(float price, float cost, int exDate, bool buttered) : BakeryProd(price, cost, exDate)
{
    private bool Buttered
    {
        get;
        set;
    } = buttered;
}