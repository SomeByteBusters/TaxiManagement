namespace TaxiManagement0;

public class Pretzel(float price, float cost, int exDate, bool buttered) : BakeryProd(price, cost, exDate)
{
    public bool Buttered
    {
        get;
        private set;
    } = buttered;
}