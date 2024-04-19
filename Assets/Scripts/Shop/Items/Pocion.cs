using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : Item
{
    public int extraHP;

    public int getHP()
    {
        return this.extraHP;
    }

    public void setHP(int extraHP)
    {
        this.extraHP = extraHP;
    }

    public Pocion(string itemName, int itemId, int itemCost, int itemQty, int extraHP) : base(itemName, itemId, itemCost, itemQty)
    {
        this.setCost(itemCost);
        this.setQty(itemQty);
        this.setId(itemId);
        this.setName(itemName);
        this.setHP(extraHP);

    }

    public override Item clone()
    {
        return new Pocion(this.getName(), this.getId(), this.getCost(), this.getQty(), this.getHP());
    }


}
