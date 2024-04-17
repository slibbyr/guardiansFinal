using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tavern : MonoBehaviour
{
    public int selectedHero = 0;
    public Gestor gestor;

    public void selectHero(int pClass)
    {
        selectedHero = pClass;
    } 

    public void recluteHero()
    {
        //gestor = GameObject.Find("Gestor").GetComponent<Gestor>();
        Debug.Log("Click");
       // gestor.new_hero(selectedHero);
       // Debug.Log(gestor.getHeroData());
    }
}
