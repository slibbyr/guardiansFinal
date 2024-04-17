using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestor : MonoBehaviour, IDataPersistence
{
    private  List<Hero> arrHeroes = new List<Hero>();
    private static Abstract_Factory gFabric;

    public Gestor()
    {
        gFabric = new Hero_Factory();
    }

    public void new_hero(int pHeroClass)
    {
        AddHeroArray(gFabric.CreateHero(pHeroClass));
    }
    private void AddHeroArray(Hero pHero)
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

    public void LoadData(GameData data)
    {
        this.arrHeroes = data.heroes;
    }

    public void SaveData(GameData data)
    {
        data.heroes = this.arrHeroes;
    }
}
