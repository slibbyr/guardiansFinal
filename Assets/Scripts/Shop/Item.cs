using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    private string itemName;
    private int itemId;
    private int itemCost;
    private int itemQty;

    public Item(string itemName, int itemId, int itemCost, int itemQty)
    {
        this.itemName = itemName;
        this.itemId = itemId;
        this.itemCost = itemCost;
        this.itemQty = itemQty;
    }

    public string getName()
    {
        return this.itemName;
    }

    public void setName(string name)
    {
        this.itemName = name;
    }

    public int getId()
    {
        return this.itemId;
    }

    public void setId(int id)
    {
        this.itemId = id;
    }
    public int getCost()
    {
        return this.itemCost;
    }
    public int getQty()
    {
        return this.itemQty;
    }
    public void setQty(int qty) { 
        this.itemQty = qty;
    }
    
    public void setCost(int cost)
    {
        this.itemCost = cost;
    }

    public abstract Item clone();
}
