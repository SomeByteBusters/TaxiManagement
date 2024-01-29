namespace TaxiManagement0;

public abstract class Product(float price, float cost, int exDate)
{
    public float Price
    {
        get;
        protected set;
    } = price;
    
    public float Cost
    {
        get;
        protected set;
    } = cost;
    
    public int ExDate
    {
        get;
        private set;
    } = exDate;
}