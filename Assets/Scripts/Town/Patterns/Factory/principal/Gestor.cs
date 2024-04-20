using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestor : MonoBehaviour
{
    private  List<Hero> arrHeroes = new List<Hero>();
    private static Abstract_Factory gFabric;

    public Gestor()
    {
        gFabric = new Hero_Factory();
    }

    public void new_hero(int pHeroClass)
    {
        Debug.Log("Start adding array object");
        AddHeroArray(gFabric.CreateHero(pHeroClass));
        PlayerManager.Instance.AddHeroToTeam(pHeroClass);
        Debug.Log("Finish adding array");
    }
    private void AddHeroArray(Hero pHero)
    {
        arrHeroes.Add(pHero);
        Debug.Log("Add hero call");
    }

    public string getHeroData()
    {
        string mResult = "";
        foreach (Hero h in arrHeroes)
        {
            mResult += h.Name + "/n";
        }

        return mResult;
    }

}
