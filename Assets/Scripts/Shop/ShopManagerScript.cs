using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public float coins;
    public TMP_Text CoinsTXT;
    public TMP_Text QtyTXT;
    public static Gestor_Items items;

    void Start()
    {
        CoinsTXT.text = "Monedas: " + coins.ToString();


        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 20;
        shopItems[2, 2] = 40;
        shopItems[2, 3] = 50;
        shopItems[2, 4] = 60;

        //Qty
        shopItems[3, 1] = 1;
        shopItems[3, 2] = 3;
        shopItems[3, 3] = 1;
        shopItems[3, 4] = 1;



    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(coins >= shopItems[2, ButtonRef.GetComponent<StoreButtonInfo>().ItemID]){  

            if (shopItems[3, ButtonRef.GetComponent<StoreButtonInfo>().ItemID] > 0)
            {
                coins -= shopItems[2, ButtonRef.GetComponent<StoreButtonInfo>().ItemID];
                CoinsTXT.text = "Coins: " + coins.ToString();
                //QtyTXT.text = shopItems[3, ButtonRef.GetComponent<StoreButtonInfo>().ItemID].ToString();
                shopItems[3, ButtonRef.GetComponent<StoreButtonInfo>().ItemID]--;
            } else
            {
                Debug.Log("No puedes comprar más artículos de la cantidad permitida.");
            }
        } else
        {
            Debug.Log("No tienes las monedas suficientes para comprar este objeto.");
        }

    }
}
