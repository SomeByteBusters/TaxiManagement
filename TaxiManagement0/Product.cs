namespace TaxiManagement0;

public abstract class Product(float price, float cost, float exDate)
{
    protected float Price
    {
        get;
    } = price;
    
    protected float Cost
    {
        get;
    } = cost;
    
    protected float ExDate
    {
        get;
    } = exDate;
}