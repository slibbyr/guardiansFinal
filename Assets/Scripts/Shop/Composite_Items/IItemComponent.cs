using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemComponent
{
    public string GetName();
    public int GetPrice();
    public int GetQuantity();
    public void UseItem(int amount);

    public void SetQuantity(int quantity);


}
