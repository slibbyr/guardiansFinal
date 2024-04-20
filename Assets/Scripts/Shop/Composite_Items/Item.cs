public class Item : IItemComponent
{
    private string name;
    private int price;
    private int quantity;


    public Item(string name, int price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName()
    {
        return name;
    }

    public int GetPrice()
    {
        return price;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void SetQuantity (int quantity)
    {
        this.quantity=quantity;
    }

    public void UseItem(int amount)
    {
        quantity -= amount;
    }
}