using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StoreButtonInfo : MonoBehaviour
{

    public int ItemID;
    public TMP_Text PriceTxt;
    public TMP_Text QtyTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = "$" + ShopManager.GetComponent<ShopManagerScript>().shopItems[ItemID].GetPrice().ToString();
        QtyTxt.text = "Qty: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[ItemID].GetQuantity().ToString();

    }
}
