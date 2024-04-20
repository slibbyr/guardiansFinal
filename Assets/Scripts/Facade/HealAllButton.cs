using Product;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealAllButton : MonoBehaviour
{
    public List<Hero> heroes;

    private HealingFacade healingFacade;

    private void Start()
    {
        healingFacade = new HealingFacade(heroes);

        Button button = GetComponent<Button>();
        //button.onClick.AddListener(HealAllHeroes);
        Debug.Log("Healing all Heroes");
    }

    private void HealAllHeroes()
    {
        healingFacade.HealAllHeroes();
    }
}