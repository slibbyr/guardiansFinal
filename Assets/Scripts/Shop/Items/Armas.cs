using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : Item
{
    public double extraDamage;

    public double getDamage()
    {
        return this.extraDamage;
    }

    public void setDamage(double extraDamage)
    {
        this.extraDamage = extraDamage;
    }

    public Armas(string itemName, int itemId, int itemCost, int itemQty, double extraDamage) : base(itemName, itemId, itemCost, itemQty)
    {
        this.setCost(itemCost);
        this.setQty(itemQty);
        this.setId(itemId);
        this.setName(itemName);
        this.setDamage(extraDamage);

    }

    public override Item clone()
    {
        return new Armas(this.getName(), this.getId(), this.getCost(), this.getQty(), this.getDamage());
    }


}
