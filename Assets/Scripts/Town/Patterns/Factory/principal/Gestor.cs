using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestor : MonoBehaviour
{
    private static List<Hero> arrHeroes = new List<Hero>();
    private static Abstract_Factory gFabric;

    public Gestor()
    {
        gFabric = new Hero_Factory();
    }

    public void new_hero(int pHeroClass)
    {
        AddHeroArray(gFabric.CreateHero(pHeroClass));
    }
    private static void AddHeroArray(Hero pHero)
    {
        arrHeroes.Add(pHero);
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
