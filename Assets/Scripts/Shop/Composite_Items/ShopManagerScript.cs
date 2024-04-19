using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    private ItemCategory weaponsCategory;
    private ItemCategory upgradesCategory;

    public IItemComponent[] shopItems = new IItemComponent[5];
    public TMP_Text qtyText;
    public TMP_Text priceText;
    public double coins;

    void Start()
    {
        weaponsCategory = new ItemCategory("Armas");
        upgradesCategory = new ItemCategory("Mejoras");
        coins = PlayerManager.Instance.GetCoinBalance();

        Item pocion = new Item("Poción", 40, 10); 

        upgradesCategory.AddItem(pocion);

        Item elfoBow = new Item("Arco para Elfo", 20, 5);
        Item berserkerDagger = new Item("Daga para Berserker", 50, 3);
        Item paladinAxe = new Item("Hacha para Paladin", 60, 4);

        weaponsCategory.AddItem(elfoBow);
        weaponsCategory.AddItem(berserkerDagger);
        weaponsCategory.AddItem(paladinAxe);

        shopItems[1] = weaponsCategory.GetChild(0);
        shopItems[2] = upgradesCategory.GetChild(0);
        shopItems[3] = weaponsCategory.GetChild(1);
        shopItems[4] = weaponsCategory.GetChild(2);

        
    }

    public void Buy()
    {
        // Lógica para comprar un ítem seleccionado (usando patrón Composite)
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].GetQuantity() > 0)
        {
            if (coins >= shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].GetPrice())
            {
                PlayerManager.Instance.SpendCoins(shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].GetPrice());
                int newQty = shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].GetQuantity() - 1;
                shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].SetQuantity(newQty);

                ButtonRef.GetComponent<StoreButtonInfo>().QtyTxt.text = shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].GetQuantity().ToString();
                
                if(shopItems[ButtonRef.GetComponent<StoreButtonInfo>().ItemID].GetName() == "Poción")
                {
                    PlayerManager.Instance.IncreaseHeroHealth(15);
                }
            
            }else
            {
                Debug.Log("Ya no tienes las monedas requeridas.");
            }

            
        } else
        {
            Debug.Log("Ya se agoto la cantidad existente");
        }
        
    }
}
