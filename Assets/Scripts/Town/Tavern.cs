using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tavern : MonoBehaviour
{
    public int selectedHero = 0;
    public Gestor gestor;
    public GameObject teamGameObject;

    public void selectHero(int pClass)
    {
        selectedHero = pClass;
    } 

    public void recluteHero()
    {
        gestor = GameObject.Find("Gestor").GetComponent<Gestor>();
        gestor.new_hero(selectedHero);
        Debug.Log(gestor.getHeroData());
    }

    public void ToggleTeamGameObject()
    {
        if (teamGameObject != null)
        {
            teamGameObject.SetActive(!teamGameObject.activeSelf);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un GameObject 'Team' en el Inspector.");
        }
    }
}
