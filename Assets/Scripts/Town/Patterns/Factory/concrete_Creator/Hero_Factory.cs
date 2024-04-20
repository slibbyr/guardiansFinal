using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Product;
using ConcreteProduct;

public class Hero_Factory : Abstract_Factory
{
    public Hero CreateHero(int pHeroClass)
    {
        Hero newHero;

        switch (pHeroClass)
        {
            case 1:
                Debug.Log("Creating hero with class: " + pHeroClass);
                newHero = new Berserker("Arion", 1, 10, 50, 30, 25);
                break;
            case 2:
                Debug.Log("starting new Paladin");
                Debug.Log("created Paladin");
                newHero = new Paladin("Paladin", 2, 5, 50, 50, 25);
                break;
            case 3:
                Debug.Log("starting new Elf");
                Debug.Log("created Elf");
                newHero = new Elf("Elf", 3, 5, 50, 50, 25);
                break;
            default:
                Debug.Log("new Default");
                newHero = new Paladin("Paladin", 2, 5, 50, 50, 25);
                break;
        }

        return newHero;
    }

}
