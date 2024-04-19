using System.Collections.Generic;

public class ItemCategory : IItemComponent
{
    private string name;
    private List<IItemComponent> children;

    public ItemCategory(string name)
    {
        this.name = name;
        children = new List<IItemComponent>();
    }

    public void AddItem(IItemComponent item)
    {
        children.Add(item);
    }

    public string GetName()
    {
        return name;
    }

    public int GetPrice()
    {
        int totalPrice = 0;
        foreach (var child in children)
        {
            totalPrice += child.GetPrice();
        }
        return totalPrice;
    }

    public int GetQuantity()
    {
        int totalQuantity = 0;
        foreach (var child in children)
        {
            totalQuantity += child.GetQuantity();
        }
        return totalQuantity;
    }

    public void SetQuantity(int quantity)
    {
        foreach (var child in children)
        {
            child.SetQuantity(quantity);
        }
        
    }

    public IItemComponent GetChild(int itemId)
    {
        IItemComponent item = children[itemId];

        return item;
    }

    public void UseItem(int amount)
    {
        foreach (var child in children)
        {
            child.UseItem(amount);
        }
    }
}