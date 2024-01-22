namespace TaxiManagement0;

public class Pretzel(float price, bool buttered) : BakeryProd(price)
{
    private bool Buttered
    {
        get;
        set;
    } = buttered;
}